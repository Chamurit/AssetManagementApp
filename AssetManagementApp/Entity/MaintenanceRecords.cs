using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{
    public class Maintenance_records
    {
        // Private variables
        private int maintenanceID;
        private int assetID;
        private DateTime maintenanceDate;
        private string description;
        private double cost;

        // Default constructor
        public Maintenance_records() { }

        // Parameterized constructor
        public Maintenance_records(int maintenanceID, int assetID, DateTime maintenanceDate, string description, double cost)
        {
            this.maintenanceID = maintenanceID;
            this.assetID = assetID;
            this.maintenanceDate = maintenanceDate;
            this.description = description;
            this.cost = cost;
        }

        // Getter and Setter methods
        public int MaintenanceID
        {
            get { return maintenanceID; }
            set { maintenanceID = value; }
        }

        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        public DateTime MaintenanceDate
        {
            get { return maintenanceDate; }
            set { maintenanceDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }

}
