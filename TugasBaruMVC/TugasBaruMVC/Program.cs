using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBaruMVC.Models;
using TugasBaruMVC.Repositories.Data;

namespace TugasBaruMVC
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Untuk GET ALL
            /*
            DivisionRepository divisionRepository = new DivisionRepository();
            var data = divisionRepository.Get();
            foreach (var item in data)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }
            */
            /*
            DepartmentRepository departmentRepository = new DepartmentRepository();
            var data = departmentRepository.Get();
            foreach (var item in data)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.DivisionId);
                Console.WriteLine();
            }
            */


            // Untuk GET Id
            /*
            DivisionRepository divisionRepository = new DivisionRepository();
            var data = divisionRepository.Get(2);
            Console.WriteLine(data.Id);
            Console.WriteLine(data.Name);
            Console.WriteLine();
            */
            /*
            DepartmentRepository departmentRepository = new DepartmentRepository();
            var data = departmentRepository.Get(2);
            Console.WriteLine(data.Id);
            Console.WriteLine(data.Name);
            Console.WriteLine(data.DivisionId);
            Console.WriteLine();
            */

            // Untuk Insert Data
            /*
            Division division = new Division(0, "IT Support");
            DivisionRepository divisionRepository = new DivisionRepository();
            var result = divisionRepository.Insert(division);
            if (result > 0)
            {
                var data = divisionRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Failed to Insert Data");
            }
            */
            /*
            Department department = new Department(0, "Aplikasi Development 3", 1);
            DepartmentRepository departmentRepository = new DepartmentRepository();
            var result = departmentRepository.Insert(department);
            if (result > 0)
            {
                var data = departmentRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.DivisionId);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Failed to Insert Data");
            }
            */


            // Untuk Update Data
            /*
            Division division = new Division(3, "Human Resource (HR)");
            DivisionRepository divisionRepository = new DivisionRepository();
            var result = divisionRepository.Update(division);
            if (result > 0)
            {
                var data = divisionRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Failed to Update Data");
            }
            */
            /*
            Department department = new Department(7, "Aplikasi Development 4", 1);
            DepartmentRepository departmentRepository = new DepartmentRepository();
            var result = departmentRepository.Update(department);
            if (result > 0)
            {
                var data = departmentRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.DivisionId);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Failed to Update Data");
            }
            */


            // Untuk Delete Data
            /*
            DivisionRepository divisionRepository = new DivisionRepository();
            var result = divisionRepository.Delete(3);
            if (result > 0)
            {
                var data = divisionRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                }
            } 
            else
            {
                Console.WriteLine("Failed to Delete Data");
            }
            */
            /*
            DepartmentRepository departmentRepository = new DepartmentRepository();
            var result = departmentRepository.Delete(7);
            if (result > 0)
            {
                var data = departmentRepository.Get();
                foreach (var item in data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.DivisionId);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Failed to Delete Data");
            }
            */
        }
    }
}
