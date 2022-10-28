using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBaruMVC.Context
{
    public class MyContext
    {
        public static string GetConnection()
        {
            return "Data Source=DESKTOP-56EIKBC\\SQLEXPRESS;Initial Catalog = db_TugasBaruMVC; User ID=mcc71;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
