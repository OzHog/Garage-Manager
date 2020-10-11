using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class Truck : Vehicle
    {
        private bool m_ContainsHazardousMaterials;
        private float m_CargoVolume;

        internal Truck(string i_LicenseNumber)
            : base(i_LicenseNumber)
        {
            m_ContainsHazardousMaterials = false;
            m_CargoVolume = 0;
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                if(m_CargoVolume == 0 && value > 0)
                {
                    m_CargoVolume = value;
                }
            }
        }

        public bool ContainsHazardousMaterials
        {
            get
            {
                return m_ContainsHazardousMaterials;
            }

            set
            {
                m_ContainsHazardousMaterials = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strTruck = new StringBuilder();

            strTruck.AppendLine("Vehicle Type: Truck");
            strTruck.Append(base.ToString());
            strTruck.AppendFormat("ContainsHazardous Materials: {0}", m_ContainsHazardousMaterials.ToString()).AppendLine();
            strTruck.AppendFormat("Cargo Volume: {0} Liter", m_CargoVolume.ToString());
        
            return strTruck.ToString();
        }
    }
}
