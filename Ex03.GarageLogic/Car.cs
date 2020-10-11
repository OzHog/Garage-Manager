using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class Car : Vehicle
    {
        private eAmountOfDoors m_AmountOfDoors;
        private eVehicleColor m_Color;

        public eVehicleColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eAmountOfDoors AmountOfDoors
        {
            get
            {
                return m_AmountOfDoors;
            }
            set
            {
                m_AmountOfDoors = value;

            }
        }

        public override string ToString()
        {
            StringBuilder strCar = new StringBuilder();

            strCar.AppendLine("Vehicle Type: Car");
            strCar.Append(base.ToString());
            strCar.AppendFormat("Amount Of Doors: {0}", m_AmountOfDoors.ToString()).AppendLine();
            strCar.AppendFormat("Color: {0}", m_Color.ToString());

            return strCar.ToString();
        }

        internal Car(string i_LicenseNumber, eVehicleColor i_Color = eVehicleColor.White, eAmountOfDoors i_AmountOfDoors = eAmountOfDoors.Five)
            : base(i_LicenseNumber)
        {
            m_Color = i_Color;
            m_AmountOfDoors = i_AmountOfDoors;
        }

    }
}
