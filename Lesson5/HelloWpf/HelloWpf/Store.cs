using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWpf.Entities;

namespace HelloWpf
{
    static class Store
    {
        public static List<Employee> EmployeeList;
        public static List<Department> DepartmentList;


        //public static List<Employee> GetEmployeeList()
        //{
        //    var result = new List<Employee>();

        //    result.Add(new Employee{Id = 0, Name = "Василий Петрович"});
        //    result.Add(new Employee { Id = 1, Name = "Леонид Васильевич" });
        //    result.Add(new Employee { Id = 2, Name = "Александр Антонович" });

        //    return result;
        //}


        //public static List<Department> GetDepartmentList()
        //{
        //    var result = new List<Department>();

        //    result.Add(new Department { Id = 0, Name = "Департамент 1" });
        //    result.Add(new Department { Id = 1, Name = "Департамент 2" });
        //    result.Add(new Department { Id = 2, Name = "Департамент 3" });

        //    return result;
        //}
    }
}
