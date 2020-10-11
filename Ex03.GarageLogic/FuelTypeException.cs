using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTypeException : Exception
    {
        private readonly eFuel r_InputFuel;
        private readonly eFuel r_RequiredFuel;

        public FuelTypeException(eFuel i_InputFuel, eFuel i_RequiredFuel)
            : base()             
        {
            r_InputFuel = i_InputFuel;
            r_RequiredFuel = i_RequiredFuel;

        }

        public eFuel InputFuel
        {
            get
            {
                return r_InputFuel;
            }
        }

        public eFuel RequiredFuel
        {
            get
            {
                return r_RequiredFuel;
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel Type Not Match, Required Fuel: {0}", r_RequiredFuel.ToString());
        }
    }
}
