using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Employees
    {
        // Private variables
        private int employeeID;
        private string name;
        private string department;
        private string email;
        private string password;

        // Default constructor
        public Employees() { }

        // Parameterized constructor
        public Employees(int employeeID, string name, string department, string email, string password)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.department = department;
            this.email = email;
            this.password = password;
        }

        // Getter and Setter methods
        public int GetEmployeeID() => employeeID;
        public void SetEmployeeID(int employeeID) => this.employeeID = employeeID;

        public string GetName() => name;
        public void SetName(string name) => this.name = name;

        public string GetDepartment() => department;
        public void SetDepartment(string department) => this.department = department;

        public string GetEmail() => email;
        public void SetEmail(string email) => this.email = email;

        public string GetPassword() => password;
        public void SetPassword(string password) => this.password = password;
    }
}

