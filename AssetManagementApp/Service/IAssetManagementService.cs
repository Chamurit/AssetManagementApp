using AssetManagementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Service
{
    public interface IAssetManagementService
    {
        bool AddAsset(Assets asset);
        bool UpdateAsset(Assets asset);
        bool DeleteAsset(int assetId);
        bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate);
        bool DeallocateAsset(int assetId, int employeeId, DateTime returnDate);
        bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost);
        bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate);
        bool WithdrawReservation(int reservationId);
        List<Assets> GetAllAsset();
    }
}
