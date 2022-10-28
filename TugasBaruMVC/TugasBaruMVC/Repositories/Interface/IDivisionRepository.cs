using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBaruMVC.Models;

namespace TugasBaruMVC.Repositories.Interface
{
    public interface IDivisionRepository
    {
        List<Division> Get();
        Division Get(int id);
        int Insert(Division division);
        int Update(Division division);
        int Delete(int id);
    }
}
