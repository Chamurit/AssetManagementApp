using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Asset_Allocations
    {
        // Private variables
        private int allocationID;
        private int assetID;
        private int employeeID;
        private DateTime allocationDate;
        private DateTime returnDate;

        // Default constructor
        public Asset_Allocations() { }

        // Parameterized constructor
        public Asset_Allocations(int allocationID, int assetID, int employeeID, DateTime allocationDate, DateTime returnDate)
        {
            this.allocationID = allocationID;
            this.assetID = assetID;
            this.employeeID = employeeID;
            this.allocationDate = allocationDate;
            this.returnDate = returnDate;
        }

        // Getter and Setter methods
        public int AllocationID
        {
            get { return allocationID; }
            set { allocationID = value; }
        }

        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public DateTime AllocationDate
        {
            get { return allocationDate; }
            set { allocationDate = value; }
        }

        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
    }
}
