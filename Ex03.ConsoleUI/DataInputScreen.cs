using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public sealed class DataInputScreen : InputScreen
    {

        public DataInputScreen(string i_MassageToDisplay = null) : base(i_MassageToDisplay) {}

        protected override bool isUserInputLegal(string i_UserInput)
        {
            bool inputLegal = i_UserInput.Length > 0;

            if(!inputLegal)
            {
                throw new EmptyInputException();
            }

            return inputLegal;
        }
    }
}
