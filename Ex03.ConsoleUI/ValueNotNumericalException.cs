using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class ValueNotNumericalException : Exception
    {
        private readonly string r_Value;

        public ValueNotNumericalException(string i_Value)
            : base()
        {
            r_Value = i_Value;
        }

        public string Input
        {
            get
            {
                return r_Value;
            }
        }

        public override string ToString()
        {
            return "Input Have To Be Numerical And Positive";
        }

    }
}
