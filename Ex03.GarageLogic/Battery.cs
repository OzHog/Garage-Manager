using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        public Battery(float i_TimeCapacity)
            : base(i_TimeCapacity) {}

        public float TimeCapacity
        {
            get
            {
                return base.r_Capacity;
            }
        }

        public float TimeLeft
        {
            get
            {
                return base.m_Amount;
            }
        }

        public void Charge(float i_TimeToAdd)
        {
            bool chargeSucceeded = base.add(i_TimeToAdd);

            if (!chargeSucceeded)
            {
                throw new AmountOutOfCapacityException(i_TimeToAdd, TimeLeft, TimeCapacity, "Hours");
            }
        }

        public override string ToString()
        {
            StringBuilder strBattery = new StringBuilder();

            strBattery.AppendFormat("Time Capacity: {0} Hours", TimeCapacity.ToString()).AppendLine();
            strBattery.AppendFormat("Time Left: {0} Hours", TimeLeft.ToString());

            return strBattery.ToString();
        }
    }
}
