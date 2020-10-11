using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class AmountOutOfCapacityException : Exception
    {
        private readonly float r_AmountToAdd;
        private readonly float r_CurrentAmount;
        private readonly float r_Capacity;
        private readonly string r_UnitAmount;

        public AmountOutOfCapacityException(float i_AmountToAdd, float i_CurrentAmount, float i_Capacity, string i_UnitAmount)
            : base()
        {
            r_AmountToAdd = i_AmountToAdd;
            r_Capacity = i_Capacity;
            r_CurrentAmount = i_CurrentAmount;
            r_UnitAmount = i_UnitAmount;
        }

        public float AmountToAdd
        {
            get
            {
                return r_AmountToAdd;
            }
        }

        public float CurrentAmount
        {
            get
            {
                return r_CurrentAmount;
            }
        }

        public float Capacity
        {
            get
            {
                return r_Capacity;
            }
        }

        public string UnitAmount
        {
            get
            {
                return r_UnitAmount;
            }
        }

        public override string ToString()
        {
            return string.Format("Amount Out Of Capacity Exception: {0} {1} Will Pass The Maximum Capacity\n Current Amount: {2} / {3} {4}", r_AmountToAdd, r_UnitAmount, r_CurrentAmount, r_Capacity, r_UnitAmount);
        }
    }
}
