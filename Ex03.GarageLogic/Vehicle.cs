using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        protected readonly List<Wheel> r_Wheels;
        protected EnergySource m_EnergySource;

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }

        public virtual string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public virtual string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                if(m_ModelName == null)
                {
                    m_ModelName = value;
                }
            }
        }

        public virtual float CurrentEnergySourcePercentage
        {
            get
            {
                float amount = 0;
                float capacity = 0;

                if(m_EnergySource is Battery)
                {
                    capacity = (m_EnergySource as Battery).TimeCapacity;
                    amount = (m_EnergySource as Battery).TimeLeft;
                }
                else
                {
                    capacity = (m_EnergySource as FuelTank).FuelCapacity;
                    amount = (m_EnergySource as FuelTank).CurrentFuelAmount;
                }

                float energySourcePercentage = (amount / capacity) * 100f;
                return energySourcePercentage;
            }
        }
        
        public virtual EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
            set
            {
                m_EnergySource = value;
            }
        }

        internal Vehicle(string i_LicenseNumber)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>(0);
            m_ModelName = null;
            m_EnergySource = null;
        }

        public override string ToString()
        {

            StringBuilder strVehicle = new StringBuilder();
            strVehicle.AppendFormat("License Number: {0}", r_LicenseNumber).AppendLine();
            strVehicle.AppendFormat("Model Name: {0}", m_ModelName).AppendLine();
            strVehicle.Append(m_EnergySource.ToString()).AppendLine();

            if(m_EnergySource is Battery)
            {
                strVehicle.AppendFormat(
                    "Current Battery Percentage: {0}%",
                    CurrentEnergySourcePercentage.ToString()).AppendLine();
            }
            else
            {
                strVehicle.AppendFormat(
                    "Current Fuel Percentage: {0}%",
                    CurrentEnergySourcePercentage.ToString()).AppendLine();
            }

            int wheelCounter = 1;
            foreach (Wheel wheel in r_Wheels)
            {
                strVehicle.AppendFormat("Wheel {0}: {1}", wheelCounter.ToString(), wheel.ToString()).AppendLine();
                wheelCounter++;
            }

            return strVehicle.ToString();
        }
    }
}
