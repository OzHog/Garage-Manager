using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base()
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Value Out Of Range Exception: Min Value = {0}, Max Value = {1}",
                r_MinValue,
                r_MaxValue);
        }
    }
}
