using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Payroll.Employees;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Executive(3),
                new Manager(5),
                new Director(5)
            };

            foreach (var employee in employeeList)
            {
                Console.WriteLine(employee.GetTotalCompanyContributions());
                Console.WriteLine(employee.GetTotalPension());
                Console.WriteLine(employee.EmployeeType());
            }
            Console.ReadLine();
        }
    }
}
