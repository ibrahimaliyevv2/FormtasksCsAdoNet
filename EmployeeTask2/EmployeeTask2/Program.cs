using System;
using EmployeeTask2.Models;

namespace EmployeeTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeesData employeeData = new EmployeesData();
            //employeeData.AddEmployee("testt");
            employeeData.DeleteEmployee(11);
            foreach (var item in employeeData.GetEmployeeFullName())
            {
                Console.WriteLine(item);
            };
            //Console.WriteLine(employeeData.GetEmployeeById(5)); 

        }
    }
}
