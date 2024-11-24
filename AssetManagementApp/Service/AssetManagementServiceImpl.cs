

using AssetManagementApp.Entity;
using AssetManagementApp.Exception;
using AssetManagementApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Service
{
    public class AssetManagementServiceImpl : IAssetManagementService
    {
        string connectionString;
        private readonly object Command;
        SqlCommand command = null;

        // Constructor to initialize the database connection string
        public AssetManagementServiceImpl()
        {
            connectionString = DBPropertyUtil.GetConnectionString();
            command = new SqlCommand(connectionString);
        }

        public List<Assets> GetAllAsset()
        {
            List<Assets> asset = new List<Assets>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ASSETS";
                SqlCommand command = new SqlCommand(query, connection);
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Assets assets = new Assets();

                        assets.AssetID = (int)reader["AssetID"];
                        assets.Names = (string)reader["Names"];
                        assets.Type = (string)reader["Type"];
                        assets.SerialNumber = (int)reader["SerialNumber"];
                        assets.PurchaseDate = (DateTime)reader["PurchaseDate"];
                        assets.Locations = (string)reader["Locations"];
                        assets.Status = (string)reader["Status"];
                        assets.OwnerID = (int)reader["OwnerID"];
                        asset.Add(assets);
                    }


                }
            }
            return asset;
        }

        public bool AddAsset(Assets asset)
        {
            string query = "INSERT INTO Assets VALUES (@Names, @Type, @SerialNumber, @PurchaseDate, @Locations, @Status, @OwnerID)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Names", asset.Names);
                command.Parameters.AddWithValue("@Type", asset.Type);
                command.Parameters.AddWithValue("@SerialNumber", asset.SerialNumber);
                command.Parameters.AddWithValue("@PurchaseDate", asset.PurchaseDate);
                command.Parameters.AddWithValue("@Locations", asset.Locations);
                command.Parameters.AddWithValue("@Status", asset.Status);
                command.Parameters.AddWithValue("@OwnerID", asset.OwnerID);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateAsset(Assets asset)
        {
            string query = "UPDATE Assets SET SerialNumber = @SerialNumber WHERE AssetID = @AssetID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AssetID", asset.AssetID);
                command.Parameters.AddWithValue("@SerialNumber", asset.SerialNumber);


                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();

                return true;
            }
        }

        public bool DeleteAsset(int assetid)
        {
            string query = "delete from Assets where AssetID = @AssetID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))

            {
                command.Parameters.AddWithValue("@Assetid", assetid);

                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected == 0)
                {
                    throw new AssetNotFoundException($"Asset with ID::{assetid} not found in database");
                }
                return true;
            }
        }


        public bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Asset_Allocations (AssetId, EmployeeId, AllocationDate) 
                                 VALUES (@AssetId, @EmployeeId, @AllocationDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AssetId", assetId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@AllocationDate", allocationDate);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeallocateAsset(int assetId, int employeeId, DateTime returnDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Asset_Allocations
                                 SET ReturnDate = @ReturnDate 
                                 WHERE AssetId = @AssetId AND EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssetId", assetId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AssetNotFoundException($"Asset with ID::{assetId} not found in database");
                    }
                    return rowsAffected > 0;
                }
            }
        }
        public bool PerformMaintenance(int assetId, DateTime maintenanceDate, string description, double cost)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Maintenance_Records (AssetId, MaintenanceDate, Description, Cost) 
                                 VALUES (@AssetId, @MaintenanceDate, @Description, @Cost)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AssetId", assetId);
                    command.Parameters.AddWithValue("@MaintenanceDate", maintenanceDate);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Cost", cost);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();



                    if ((DateTime.Now - maintenanceDate).TotalDays > 730)
                    {
                        throw new AssetNotMaintainException($"Asset with ID::{assetId} has not been maintained for over 2 years");
                    }
                    return rowsAffected > 0;
                }
            }

        }
        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Reservations (AssetId, EmployeeId, ReservationDate, StartDate, EndDate) 
                                 VALUES (@AssetId, @EmployeeId, @ReservationDate, @StartDate, @EndDate)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssetId", assetId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public bool WithdrawReservation(int reservationId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Reservations WHERE ReservationId = @ReservationId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReservationId", reservationId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AssetNotFoundException($"Asset with ReservationID::{reservationId} not found in database");
                    }

                    return rowsAffected > 0;

                }
            }
        }

    }
}
