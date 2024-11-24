using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Entity
{

    public class Reservations
    {
        // Private variables
        private int reservationID;
        private int assetID;
        private int employeeID;
        private DateTime reservationDate;
        private DateTime startDate;
        private DateTime endDate;
        private string status;

        // Default constructor
        public Reservations() { }

        // Parameterized constructor
        public Reservations(int reservationID, int assetID, int employeeID, DateTime reservationDate, DateTime startDate, DateTime endDate, string status)
        {
            this.reservationID = reservationID;
            this.assetID = assetID;
            this.employeeID = employeeID;
            this.reservationDate = reservationDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.status = status;
        }

        // Getter and Setter methods
        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public DateTime ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
