using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleNotExistException : Exception
    {
        private readonly string r_LicenseNumber;

        public VehicleNotExistException(string i_LicenseNumber)
            : base()
        {
            r_LicenseNumber = i_LicenseNumber;
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public override string ToString()
        {
            return string.Format("License Number: {0} Dose Not Exist In The Garage", r_LicenseNumber);
        }
    }
}
