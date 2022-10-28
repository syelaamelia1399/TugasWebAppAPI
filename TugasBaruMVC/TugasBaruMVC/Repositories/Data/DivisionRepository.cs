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
    public class DivisionRepository : IDivisionRepository
    {
        SqlConnection sqlConnection;

        public List<Division> Get()
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            List<Division> divisions = new List<Division>();
            try
            {
                // membuat instance untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division";

                // membuka koneksi
                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    // mengecek apakah ada data atau tidak
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Division division = new Division(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString());
                            divisions.Add(division);
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
            return divisions;
        }

        public Division Get(int id)
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            Division divisions = new Division();
            try
            {
                // membuat instance untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division WHERE Id = @id";

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
                            divisions = new Division(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString());
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
            return divisions;
        }

        public int Insert(Division division)
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
                    sqlCommnad.CommandText = "INSERT INTO Division (Name) VALUES (@name);";
                    SqlParameter parameterName = new SqlParameter();
                    parameterName.ParameterName = "@name";
                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterName.Value = division.Name;
                    sqlCommnad.Parameters.Add(parameterName);
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

        public int Update(Division division)
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
                    sqlCommnad.CommandText = "UPDATE Division SET Name = @name WHERE Id = @id;";
                    SqlParameter parameterName = new SqlParameter();
                    SqlParameter parameterId = new SqlParameter();

                    parameterName.ParameterName = "@name";
                    parameterId.ParameterName = "@id";

                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterId.SqlDbType = SqlDbType.Int;

                    parameterName.Value = division.Name;
                    parameterId.Value = division.Id;

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
                    sqlCommnad.CommandText = "DELETE Division WHERE Id = @id;";
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
