using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBaruMVC.Context;
using TugasBaruMVC.Models;
using TugasBaruMVC.Repositories.Interface;

namespace TugasBaruMVC.Repositories.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SqlConnection sqlConnection;

        public List<Department> Get()
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            List<Department> departments = new List<Department>();
            try
            {
                // membuat instance untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Department";

                // membuka koneksi
                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    // mengecek apakah ada data atau tidak
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Department department = new Department(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString(), Convert.ToInt32(sqlDataReader[2]));
                            departments.Add(department);
                            // Console.WriteLine("Id : " + sqlDataReader[0]);
                            // Console.WriteLine("Name : " + sqlDataReader[1]);
                            // Console.WriteLine();
                        }
                    }
                    else
                    {
                        // jika tidak ada, maka menampilkan kalimat dibawah ini
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return departments;
        }

        public Department Get(int id)
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            Department departments = new Department();
            try
            {
                // membuat instance untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Department WHERE Id = @id";

                SqlParameter ParameterId = new SqlParameter();
                ParameterId.ParameterName = "@id";
                ParameterId.SqlDbType = SqlDbType.Int;
                ParameterId.Value = id;

                sqlCommand.Parameters.Add(ParameterId);

                // membuka koneksi
                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    // mengecek apakah ada data atau tidak
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            departments = new Department(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString(), Convert.ToInt32(sqlDataReader[2]));
                        }
                    }
                    else
                    {
                        // jika tidak ada, maka menampilkan kalimat dibawah ini
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return departments;
        }

        public int Insert(Department department)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(MyContext.GetConnection()))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommnad = sqlConnection.CreateCommand();
                sqlCommnad.Transaction = sqlTransaction;

                try
                {
                    sqlCommnad.CommandText = "INSERT INTO Department (Name, DivisionId) VALUES (@name, @divisionid);";

                    SqlParameter parameterName = new SqlParameter();
                    SqlParameter parameterDivisionId = new SqlParameter();

                    parameterName.ParameterName = "@name";
                    parameterDivisionId.ParameterName = "@divisionid";

                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterDivisionId.SqlDbType = SqlDbType.Int;

                    parameterName.Value = department.Name;
                    parameterDivisionId.Value = department.DivisionId;

                    sqlCommnad.Parameters.Add(parameterName);
                    sqlCommnad.Parameters.Add(parameterDivisionId);

                    result = sqlCommnad.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    };
                }
                return result;
            }
        }

        public int Update(Department department)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(MyContext.GetConnection()))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommnad = sqlConnection.CreateCommand();
                sqlCommnad.Transaction = sqlTransaction;

                try
                {
                    sqlCommnad.CommandText = "UPDATE Department SET Name = @name WHERE Id = @id;";
                    SqlParameter parameterName = new SqlParameter();
                    SqlParameter parameterId = new SqlParameter();

                    parameterName.ParameterName = "@name";
                    parameterId.ParameterName = "@id";

                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterId.SqlDbType = SqlDbType.Int;

                    parameterName.Value = department.Name;
                    parameterId.Value = department.Id;

                    sqlCommnad.Parameters.Add(parameterName);
                    sqlCommnad.Parameters.Add(parameterId);

                    result = sqlCommnad.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    };
                }
                return result;
            }
        }

        public int Delete(int id)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(MyContext.GetConnection()))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommnad = sqlConnection.CreateCommand();
                sqlCommnad.Transaction = sqlTransaction;

                try
                {
                    sqlCommnad.CommandText = "DELETE Department WHERE Id = @id;";
                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@id";
                    parameterId.SqlDbType = SqlDbType.Int;
                    parameterId.Value = id;
                    sqlCommnad.Parameters.Add(parameterId);
                    result = sqlCommnad.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        Console.WriteLine(exRollBack.Message);
                    };
                }
                return result;
            }
        }
    }
}
