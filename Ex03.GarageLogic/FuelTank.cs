using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public sealed class FuelTank : EnergySource
    {
        private readonly eFuel r_FuelType;

        public FuelTank(eFuel i_FuelType, float i_FuelCapacity)
            : base(i_FuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public eFuel FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float FuelCapacity
        {
            get
            {
                return base.r_Capacity;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return base.m_Amount;
            }
        }

        public void  Fuel(float i_AmountOFuelToAdd)
        {
            bool fuelSucceeded = base.add(i_AmountOFuelToAdd);
            if(!fuelSucceeded)
            {
                throw new AmountOutOfCapacityException(i_AmountOFuelToAdd, CurrentFuelAmount, FuelCapacity, "L");
            }
        }

        public override string ToString()
        {
            StringBuilder strFuelTank = new StringBuilder();

            strFuelTank.AppendFormat("Fuel Type: {0}", r_FuelType.ToString()).AppendLine();
            strFuelTank.AppendFormat("Fuel Capacity: {0} Liter", FuelCapacity).AppendLine();
            strFuelTank.AppendFormat("Current Fuel: {0} Liter", CurrentFuelAmount.ToString());

            return strFuelTank.ToString();
        }
    }
}
