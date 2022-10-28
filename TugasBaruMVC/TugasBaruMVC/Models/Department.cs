using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBaruMVC.Models
{
    public class Department
    {
        public Department()
        {

        }
        public Department(int Id, string Name, int DivisionId)
        {
            this.Id = Id;
            this.Name = Name;
            this.DivisionId = DivisionId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int DivisionId { get; private set; }
    }
}
