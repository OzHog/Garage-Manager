using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumAirPressure;
        private float m_CurrentAirPressure;

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }

        public Wheel(string i_ManufacturerName, float i_MaximumAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaximumAirPressure = i_MaximumAirPressure;
            m_CurrentAirPressure = 0;
        }

        public bool Inflate(float i_AmountOfAirToInflate)
        {

            bool inflateSucceeded = false;
            if(i_AmountOfAirToInflate + m_CurrentAirPressure <= r_MaximumAirPressure)
            {
                m_CurrentAirPressure += i_AmountOfAirToInflate;
                inflateSucceeded = true;
            }
            else
            {
               throw new AmountOutOfCapacityException(i_AmountOfAirToInflate, CurrentAirPressure, MaximumAirPressure, "PSI");
            }

            return inflateSucceeded;
        }

        public override string ToString()
        {
            StringBuilder strWheel = new StringBuilder();

            strWheel.AppendFormat("Manufacturer Name: {0} | ", r_ManufacturerName);
            strWheel.AppendFormat("Maximum Air Pressure: {0} PSI | ", r_MaximumAirPressure.ToString());
            strWheel.AppendFormat("Current Air Pressure: {0} PSI", m_CurrentAirPressure.ToString());

            return strWheel.ToString();
        }
    }
}
