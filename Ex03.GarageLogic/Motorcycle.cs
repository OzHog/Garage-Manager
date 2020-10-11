using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class Motorcycle : Vehicle
    {
        private eLicenseType? m_LicenseType;
        private int m_EngineCapacity;

        internal Motorcycle(string i_LicenseNumber)
            : base(i_LicenseNumber)
        {
            m_EngineCapacity = 0;
            m_LicenseType = null;
        }

        public eLicenseType? LicenseType
        {
            get
            {
                return m_LicenseType ?? null;
            }
            set
            {
                if(m_LicenseType == null)
                {
                    m_LicenseType = value;
                }
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                if (m_EngineCapacity == 0 && value > 0)
                {
                    m_EngineCapacity = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder strMotorcycle = new StringBuilder();

            strMotorcycle.AppendLine("Vehicle Type: Motorcycle");
            strMotorcycle.Append(base.ToString());
            strMotorcycle.AppendFormat("License Type: {0}", m_LicenseType.ToString()).AppendLine();
            strMotorcycle.AppendFormat("Engine Capacity: {0} cc", m_EngineCapacity.ToString());

            return strMotorcycle.ToString();
        }
    }
}
