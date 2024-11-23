using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{

    public class Assets
    {
        public int AssetId { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Locations { get; set; }
        public string Status { get; set; }
        public int OwnerId { get; set; }

        public Assets() { }

        public Assets(int assetId, string name, string type, string serialNumber, DateTime purchaseDate, string location, string status, int ownerId)
        {
            AssetId = assetId;
            Names = name;
            Type = type;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Locations = location;
            Status = status;
            OwnerId = ownerId;
        }
    }
}
