using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleExistException : Exception
    {

        private readonly string r_LicenseNumber;

        public VehicleExistException(string i_LicenseNumber)
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
            return string.Format("License Number: {0} Exist In The Data Base, Vehicle Status Changed to: In Reaper", r_LicenseNumber);
        }
    }
}
