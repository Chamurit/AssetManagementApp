using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Passwords { get; set; }

        public Employees() { }

        public Employees(int employeeId, string name, string department, string email, string password)
        {
            EmployeeId = employeeId;
            Names = name;
            Department = department;
            Email = email;
            Passwords = password;
        }
    }
}
