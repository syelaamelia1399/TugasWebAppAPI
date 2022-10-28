using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBaruMVC.Models;

namespace TugasBaruMVC.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> Get();
        Department Get(int id);
        int Insert(Department department);
        int Update(Department department);
        int Delete(int id);
    }
}
