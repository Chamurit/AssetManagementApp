using AssetManagementApp.Entity;
using AssetManagementApp.Exception;
using AssetManagementApp.Service;
using NUnit.Framework;

namespace AssetManagementApp.Tests
{
    public class Class1
    {
        
        public class AssetManagementServiceImplTests
        {
            private AssetManagementServiceImpl _service;

            [SetUp]
            public void Setup()
            {
                _service = new AssetManagementServiceImpl();
            }

            [Test]
            public void AddAsset()
            {
                //Arrange
                Assets newAsset = new Assets
                {
                    AssetID = 5,
                    Names = "Samsung",
                    Type = "Tv",
                    SerialNumber = 147853,
                    PurchaseDate = new DateTime(2024, 3, 15),
                    Locations = "Office Chennai",
                    Status = "Available",
                    OwnerID = 4
                };
                //Act
                bool result = _service.AddAsset(newAsset);
                // Assert
                Assert.That(result, "Asset should be created successfully.");
            }
            [Test]
            public void PerformMaintenance()
            {
                //Arrange
                int AssetId = 1;
                DateTime maintenanceDate = DateTime.Now;
                string description = "General checkup and software update";
                double cost = 150.50;
                // Act
                bool result = _service.PerformMaintenance(AssetId, maintenanceDate, description, cost);
                // Assert
                Assert.That(result, "Asset should be added to maintenance successfully.");
            }
            [Test]
            public void ReserveAsset()
            {
                // Arrange
                int reserveAssetId = 1;
                int reserveEmployeeId = 202;
                DateTime reservationDate = DateTime.Now;
                DateTime startDate = DateTime.Now.AddDays(1);
                DateTime endDate = DateTime.Now.AddDays(10);
                // Act
                bool result = _service.ReserveAsset(reserveAssetId, reserveEmployeeId, reservationDate, startDate, endDate);
                // Assert
                Assert.That(result, "Asset should be reserved successfully.");
            }
            [Test]
            public void DeleteAsset()
            { // Arrange
                int nonExistingAssetId = 999;
                // Act & Assert
                Assert.Throws<AssetNotFoundException>(() => _service.DeleteAsset(nonExistingAssetId), "Expected AssetNotFoundException to be thrown.");

            }

        }
    }
}
