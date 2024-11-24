
using AssetManagementApp.Entity;
using AssetManagementApp.Exception;
using AssetManagementApp.Service;
using System.Security.Cryptography.X509Certificates;



namespace DigitalAssetsManagement.main
{
    public class MainProgram
    {
        private readonly IAssetManagementService _service;

        public MainProgram(IAssetManagementService service)
        {
            _service = service;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n-----------Menu----------:");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("4. Allocate Asset");
                Console.WriteLine("5. Deallocate Asset");
                Console.WriteLine("6. Perform Maintenance");
                Console.WriteLine("7. Reserve Asset");
                Console.WriteLine("8. Withdraw Reservation");
                Console.WriteLine("9. Exit");
                Console.WriteLine("10. Get All Assets");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n1. Adding Asset...");
                            Console.Write("Enter Asset Name: ");
                            string assetName = Console.ReadLine();

                            Console.Write("Enter Asset Type: ");
                            string assetType = Console.ReadLine();

                            Console.Write("Enter Serial Number: ");
                            int serialNumber = int.Parse(Console.ReadLine());

                            Console.Write("Enter Purchase Date (yyyy-MM-dd): ");
                            DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Location: ");
                            string location = Console.ReadLine();

                            Console.Write("Enter Status: ");
                            string status = Console.ReadLine();

                            Console.Write("Enter Owner ID: ");
                            int ownerId = int.Parse(Console.ReadLine());

                            Assets newAsset = new Assets
                            {
                                Names = assetName,
                                Type = assetType,
                                SerialNumber = serialNumber,
                                PurchaseDate = purchaseDate,
                                Locations = location,
                                Status = status,
                                OwnerID = ownerId
                            };

                            Console.WriteLine(_service.AddAsset(newAsset)
                                ? "Asset added successfully."
                                : "Failed to add asset.");
                            break;

                        case 2:
                            Console.WriteLine("\n2. Updating Asset...");
                            Console.Write("Enter Asset ID to update: ");
                            int updateAssetId = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Serial Number: ");
                            int newSerialNumber = int.Parse(Console.ReadLine());

                            Assets updatedAsset = new Assets
                            {
                                AssetID = updateAssetId,
                                SerialNumber = newSerialNumber
                            };

                            Console.WriteLine(_service.UpdateAsset(updatedAsset)
                                ? "Asset updated successfully."
                                : "Failed to update asset.");
                            break;

                        case 3:
                            Console.WriteLine("\n3. Deleting Asset...");
                            Console.Write("Enter Asset ID to delete: ");
                            int assetToDelete = int.Parse(Console.ReadLine());

                            Console.WriteLine(_service.DeleteAsset(assetToDelete)
                                ? "Asset deleted successfully."
                                : "Failed to delete asset.");
                            break;

                        case 4:
                            Console.WriteLine("\n4. Allocating Asset...");
                            Console.Write("Enter Asset ID: ");
                            int allocateAssetId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Employee ID: ");
                            int allocateEmployeeId = int.Parse(Console.ReadLine());

                            DateTime allocationDate = DateTime.Now;

                            Console.WriteLine(_service.AllocateAsset(allocateAssetId, allocateEmployeeId, allocationDate)
                                ? "Asset allocated successfully."
                                : "Failed to allocate asset.");
                            break;

                        case 5:
                            Console.WriteLine("\n5. Deallocating Asset...");
                            Console.Write("Enter Asset ID: ");
                            int deallocateAssetId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Employee ID: ");
                            int deallocateEmployeeId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Return Date (yyyy-MM-dd): ");
                            DateTime returnDate = DateTime.Parse(Console.ReadLine());

                            //Console.WriteLine("Enter ReturnDate(yyy-mm-dd):");
                            // string returnDate

                            //DateTime returnDate = DateTime.Now.AddDays(12);

                            Console.WriteLine(_service.DeallocateAsset(deallocateAssetId, deallocateEmployeeId, returnDate)
                                ? "Asset deallocated successfully."
                                : "Failed to deallocate asset.");
                            break;

                        case 6:
                            Console.WriteLine("\n6. Performing Maintenance...");
                            Console.Write("Enter Asset ID: ");
                            int maintenanceAssetId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Maintenance Date (yyyy-MM-dd): ");
                            DateTime maintenanceDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Maintenance Description: ");
                            string maintenanceDescription = Console.ReadLine();

                            Console.Write("Enter Maintenance Cost: ");
                            double maintenanceCost = double.Parse(Console.ReadLine());

                            Console.WriteLine(_service.PerformMaintenance(maintenanceAssetId, maintenanceDate, maintenanceDescription, maintenanceCost)
                                ? "Maintenance recorded successfully."
                                : "Failed to record maintenance.");
                            break;

                        case 7:
                            Console.WriteLine("\n7. Reserving Asset...");
                            Console.Write("Enter Asset ID: ");
                            int reserveAssetId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Employee ID: ");
                            int reserveEmployeeId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Reservation Date (yyyy-MM-dd): ");
                            DateTime reservationDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Start Date (yyyy-MM-dd): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter End Date (yyyy-MM-dd): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine(_service.ReserveAsset(reserveAssetId, reserveEmployeeId, reservationDate, startDate, endDate)
                                ? "Asset reserved successfully."
                                : "Failed to reserve asset.");
                            break;

                        case 8:
                            Console.WriteLine("\n8. Withdrawing Reservation...");
                            Console.Write("Enter Reservation ID: ");
                            int reservationId = int.Parse(Console.ReadLine());

                            Console.WriteLine(_service.WithdrawReservation(reservationId)
                                ? "Reservation withdrawn successfully."
                                : "Failed to withdraw reservation.");
                            break;

                        case 9:
                            Console.WriteLine("Exiting the application...");
                            return;

                        case 10: // Display all assets
                            Console.WriteLine("\nDisplaying All Assets...");
                            List<Assets> allAssets = _service.GetAllAsset();

                            if (allAssets.Count == 0)
                            {
                                Console.WriteLine("No assets found in the system.");
                            }
                            else
                            {
                                Console.WriteLine("\nList of Assets:");
                                foreach (var asset in allAssets)
                                {
                                    Console.WriteLine($"AssetID: {asset.AssetID}, Names: {asset.Names}, Type: {asset.Type}, SerialNumber: {asset.SerialNumber}, PurchaseDate: {asset.PurchaseDate}, Location: {asset.Locations}, Status: {asset.Status}, OwnerID: {asset.OwnerID}");
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (AssetNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (AssetNotMaintainException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }
            }
        }
    }


}
