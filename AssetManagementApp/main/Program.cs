
using AssetManagementApp.Entity;
using AssetManagementApp.Exception;
using AssetManagementApp.Service;
using System.Security.Cryptography.X509Certificates;



namespace DigitalAssetsManagement.main
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            IAssetManagementService service = new AssetManagementServiceImpl();

          
                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Add Asset");
                    Console.WriteLine("2. Update Asset");
                    Console.WriteLine("3. Delete Asset");
                    Console.WriteLine("4. Allocate Asset");
                    Console.WriteLine("5. Deallocate Asset");
                    Console.WriteLine("6. Perform Maintenance");
                    Console.WriteLine("7. Reserve Asset");
                    Console.WriteLine("8. Withdraw Reservation");
                    Console.WriteLine("9. Exit");

                    Console.Write("Choose an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n1. Adding Asset...");
                                Assets newAsset = new Assets
                                {
                                    AssetId = 1, // Ensure a unique ID is assigned
                                    Names = "iPhone",
                                    Type = "Mobile",
                                    SerialNumber = "147852",
                                    PurchaseDate = new DateTime(2024, 1, 15),
                                    Locations = "Office X",
                                    Status = "Available",
                                    OwnerId = 2
                                };
                                Console.WriteLine(service.AddAsset(newAsset)
                                    ? "Asset added successfully."
                                    : "Failed to add asset.");
                                break;

                            case 2:
                                Console.WriteLine("\n2. Updating Asset...");
                                Assets updatedAsset = new Assets
                                {
                                    AssetId = 1, // Ensure the correct ID is used for update
                                    Names = "iPhone Updated", // Add updated properties as needed
                                    Type = "Mobile",
                                    SerialNumber = "123456",
                                    PurchaseDate = new DateTime(2024, 1, 15),
                                    Locations = "Office X",
                                    Status = "Available",
                                    OwnerId = 2
                                };
                                Console.WriteLine(service.UpdateAsset(updatedAsset)
                                    ? "Asset updated successfully."
                                    : "Failed to update asset.");
                                break;

                            case 3:
                                Console.WriteLine("\n3. Deleting Asset...");
                                int assetToDelete = 1;
                                Console.WriteLine(service.DeleteAsset(assetToDelete)
                                    ? "Asset deleted successfully."
                                    : "Failed to delete asset.");
                                break;

                            case 4:
                                Console.WriteLine("\n4. Allocating Asset...");
                                int allocateAssetId = 1;
                                int allocateEmployeeId = 1;
                                DateTime allocationDate = DateTime.Now;
                                Console.WriteLine(service.AllocateAsset(allocateAssetId, allocateEmployeeId, allocationDate)
                                    ? "Asset allocated successfully."
                                    : "Failed to allocate asset.");
                                break;

                            case 5:
                                Console.WriteLine("\n5. Deallocating Asset...");
                                int deallocateAssetId = 1;
                                int deallocateEmployeeId = 1;
                                DateTime returnDate = DateTime.Now.AddDays(7);
                                Console.WriteLine(service.DeallocateAsset(deallocateAssetId, deallocateEmployeeId, returnDate)
                                    ? "Asset deallocated successfully."
                                    : "Failed to deallocate asset.");
                                break;

                            case 6:
                                Console.WriteLine("\n6. Performing Maintenance...");
                                int maintenanceAssetId = 1;
                                DateTime maintenanceDate = DateTime.Now;
                                string maintenanceDescription = "General checkup and software update";
                                double maintenanceCost = 150.50;
                                Console.WriteLine(service.PerformMaintenance(maintenanceAssetId, maintenanceDate, maintenanceDescription, maintenanceCost)
                                    ? "Maintenance recorded successfully."
                                    : "Failed to record maintenance.");
                                break;

                            case 7:
                                Console.WriteLine("\n7. Reserving Asset...");
                                int reserveAssetId = 1;
                                int reserveEmployeeId = 202;
                                DateTime reservationDate = DateTime.Now;
                                DateTime startDate = DateTime.Now.AddDays(1);
                                DateTime endDate = DateTime.Now.AddDays(10);
                                Console.WriteLine(service.ReserveAsset(reserveAssetId, reserveEmployeeId, reservationDate, startDate, endDate)
                                    ? "Asset reserved successfully."
                                    : "Failed to reserve asset.");
                                break;

                            case 8:
                                Console.WriteLine("\n8. Withdrawing Reservation...");
                                int reservationId = 1;
                                Console.WriteLine(service.WithdrawReservation(reservationId)
                                    ? "Reservation withdrawn successfully."
                                    : "Failed to withdraw reservation.");
                                break;

                            case 9:
                                Console.WriteLine("Exiting the application...");
                                return;

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
