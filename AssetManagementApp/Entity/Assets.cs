using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{

    public class Assets
    {
        // Private variables
        private int assetID;
        private string names;
        private string type;
        private int serialNumber;
        private DateTime purchaseDate;
        private string locations;
        private string status;
        private int ownerID;

        // Default constructor
        public Assets() { }

        // Parameterized constructor
        public Assets(int assetID, string name, string type, int serialNumber, DateTime purchaseDate, string location, string status, int ownerID)
        {
            this.assetID = assetID;
            this.names = name;
            this.type = type;
            this.serialNumber = serialNumber;
            this.purchaseDate = purchaseDate;
            this.locations = location;
            this.status = status;
            this.ownerID = ownerID;
        }

        // Getter and Setter methods
        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        public string Names
        {
            get { return names; }
            set { names = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        public string Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }

       
    }
}
