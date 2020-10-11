using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
   public sealed class NumericalInputScreen : InputScreen
    {

        public NumericalInputScreen(string i_MassageToDisplay = null) : base(i_MassageToDisplay) { }

        protected override bool isUserInputLegal(string i_UserInput)
        {
            bool inputLegal = float.TryParse(i_UserInput, out float number);
            if(!inputLegal || number < 0)
            {
                throw new ValueNotNumericalException(i_UserInput);
            }

            return inputLegal;
        }
    }
}
