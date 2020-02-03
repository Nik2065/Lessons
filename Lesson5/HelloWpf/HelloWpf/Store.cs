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

        public static int GenerateDepartmentId()
        {
            int newId = 0;
            if (Store.DepartmentList != null && Store.DepartmentList.Count > 0)
            {
                var maxId = Store.DepartmentList.Select(e => e.Id).Max();
                newId = maxId++;
            }
            return newId;
        }

        public static int GenerateEmployeeId()
        {
            int newId = 0;
            if (Store.EmployeeList != null && Store.EmployeeList.Count > 0)
            {
                var maxId = Store.EmployeeList.Select(e => e.Id).Max();
                newId = maxId++;
            }
            return newId;
        }

    }
}
