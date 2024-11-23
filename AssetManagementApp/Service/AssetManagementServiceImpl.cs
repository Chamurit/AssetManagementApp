

using AssetManagementApp.Entity;
using AssetManagementApp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Service
{
    public class AssetManagementServiceImpl : IAssetManagementService
    {
        private List<Assets> assets = new List<Assets>();
        private List<AssetAllocations> allocations = new List<AssetAllocations>();
        private List<MaintenanceRecords> maintenanceRecords = new List<MaintenanceRecords>();
        private List<Reservation> reservations = new List<Reservation>();
        // private readonly Dictionary<int, Assets> assetDatabase = new Dictionary<int, Assets>();
        public bool AddAsset(Assets asset)
        {
            assets.Add(asset);
            return true;
        }

        public bool UpdateAsset(Assets asset)
        {
            var existingAsset = assets.Find(a => a.AssetId == asset.AssetId);
            if (existingAsset != null)
            {
                existingAsset.Names = asset.Names;
                existingAsset.Type = asset.Type;
                existingAsset.SerialNumber = asset.SerialNumber;
                existingAsset.PurchaseDate = asset.PurchaseDate;
                existingAsset.Locations = asset.Locations;
                existingAsset.Status = asset.Status;
                existingAsset.OwnerId = asset.OwnerId;
                return true;
            }
            return false;
        }

        public bool DeleteAsset(int assetId)
        {
            var asset = assets.Find(a => a.AssetId == assetId);
            if (asset != null)
            {
                assets.Remove(asset);
                return true;
            }
            return false;
        }

        public bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate)
        {
            var asset = assets.Find(a => a.AssetId == assetId);
            if (asset != null)
            {
                allocations.Add(new AssetAllocations(allocations.Count + 1, assetId, employeeId, allocationDate, null));
                return true;
            }
            throw new AssetNotFoundException("Asset not found.");
        }

        public bool DeallocateAsset(int assetId, int employeeId, DateTime returnDate)
        {
            var allocation = allocations.Find(a => a.AssetId == assetId && a.EmployeeId == employeeId && a.ReturnDate == null);
            if (allocation != null)
            {
                allocation.ReturnDate = returnDate;
                return true;
            }
            throw new AssetNotFoundException("Allocation not found.");
        }

        public bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost)
        {
            var asset = assets.Find(a => a.AssetId == assetId);
            if (asset != null)
            {
                maintenanceRecords.Add(new MaintenanceRecords(maintenanceRecords.Count + 1, assetId, maintenanceDate, description, cost));
                return true;
            }
            throw new AssetNotFoundException("Asset not found.");
        }

        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate)
        {
            var asset = assets.Find(a => a.AssetId == assetId);
            if (asset != null)
            {
                reservations.Add(new Reservation(reservations.Count + 1, assetId, employeeId, reservationDate, startDate, endDate, "Pending"));
                return true;
            }
            throw new AssetNotFoundException("Asset not found.");
        }

        public bool WithdrawReservation(int reservationId)
        {
            var reservation = reservations.Find(r => r.ReservationId == reservationId);
            if (reservation != null)
            {
                reservations.Remove(reservation);
                return true;
            }
            throw new AssetNotFoundException("Reservation not found.");
        }
    }
}
