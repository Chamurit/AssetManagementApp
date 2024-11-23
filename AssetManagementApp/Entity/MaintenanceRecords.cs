using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{

    public class MaintenanceRecords
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public MaintenanceRecords() { }

        public MaintenanceRecords(int maintenanceId, int assetId, DateTime maintenanceDate, string description, double cost)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            Description = description;
            Cost = cost;
        }
    }
}
