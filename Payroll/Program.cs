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
            Executive dave = new Executive(3);
            Console.WriteLine(dave.GetTotalCompanyContributions());
            Console.WriteLine(dave.GetTotalPension());
            Console.WriteLine(dave.EmployeeType());
            
            Manager james = new Manager(5);
            Console.WriteLine(james.GetTotalCompanyContributions());
            Console.WriteLine(james.GetTotalPension());
            Console.WriteLine(james.EmployeeType());

            Director susan = new Director(5);
            Console.WriteLine(susan.GetTotalCompanyContributions());
            Console.WriteLine(susan.GetTotalPension());
            Console.WriteLine(susan.EmployeeType());
            Console.ReadLine();
        }
    }
}
