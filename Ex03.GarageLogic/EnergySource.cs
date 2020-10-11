using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected readonly float r_Capacity;
        protected float m_Amount;

        protected EnergySource(float i_Capacity)
        {
            r_Capacity = i_Capacity;
            m_Amount = 0;
        }

        protected bool add(float i_AmountToAdd)
        {
            bool legalAmount = i_AmountToAdd + m_Amount <= r_Capacity;
            if (legalAmount)
            {
                m_Amount += i_AmountToAdd;
            }

            return legalAmount;
        }

        public override string ToString()
        {
            return string.Format("{0,3} {1,3}", r_Capacity, m_Amount);
        }
    }
}
