using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class EmptyInputException : Exception
    {
        private const string V = "Empty Input Exception: You Have To Enter Data";

        public EmptyInputException() : base() {}



        public override string ToString()
        {
            return "Empty Input Exception: You Have To Enter Data";
        }
    }
}
