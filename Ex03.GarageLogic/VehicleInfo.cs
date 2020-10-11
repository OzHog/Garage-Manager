using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhoneNumber;
        private eVehicleStatus m_Status;
        private Vehicle m_Vehicle;

        public VehicleInfo()
        {
            m_VehicleOwnerName = null;
            m_VehicleOwnerPhoneNumber = null;
            m_Status = eVehicleStatus.InRepair;
            m_Vehicle = null;
        }

        public string VehicleOwnerName
        {
            get {
                return m_VehicleOwnerName;
            }
            set
            {
                m_VehicleOwnerName = value;
            }
        }

        public string VehicleOwnerPhoneNumber
        {
            get
            {
                return m_VehicleOwnerPhoneNumber;
            }
            set
            {
                m_VehicleOwnerPhoneNumber = value;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }
        
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {

            string strStatus = string.Concat(m_Status.ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

            StringBuilder strVehicleInfo = new StringBuilder();
            strVehicleInfo.AppendFormat("Owner Name: {0}", m_VehicleOwnerName).AppendLine();
            strVehicleInfo.AppendFormat("Owner Phone Number: {0}", m_VehicleOwnerPhoneNumber).AppendLine();
            strVehicleInfo.AppendFormat("Vehicle Status: {0}", strStatus).AppendLine();
            strVehicleInfo.AppendFormat(m_Vehicle.ToString()).AppendLine();

            return strVehicleInfo.ToString();
        }
    }
}
