using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class AssetAllocations
    {
        public int AllocationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public AssetAllocations() { }

        public AssetAllocations(int allocationId, int assetId, int employeeId, DateTime allocationDate, DateTime? returnDate)
        {
            AllocationId = allocationId;
            AssetId = assetId;
            EmployeeId = employeeId;
            AllocationDate = allocationDate;
            ReturnDate = returnDate;
        }
    }
}
