using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class BoolInputScreen : InputScreen
    {

        public BoolInputScreen(string i_MassageToDisplay = null) : base(i_MassageToDisplay) { }


        public void Display(out bool o_UserInput)
        {
            o_UserInput = false;
            bool legalInput = false;
            string userInput = null;

            ScreenUtils.Clear();
            base.Display();
            ScreenUtils.Display(@"1. Yes
2. No");
            while (!legalInput)
            {
                userInput = ScreenUtils.GetUserInput();
                try
                {
                    legalInput = isUserInputLegal(userInput);
                }
                catch(Exception exception)
                {
                    ScreenUtils.Display(exception.ToString());
                }
            }

            o_UserInput = userInput.Equals("1");
        }

        protected override bool isUserInputLegal(string i_UserInput)
        {
            bool inputLegal = float.TryParse(i_UserInput, out float number);

            if(inputLegal)
            {
                inputLegal = i_UserInput.Equals("1") || i_UserInput.Equals("2");
                if(!inputLegal)
                {
                    throw new ValueOutOfRangeException(2,1);
                }
            }
            else
            {
                throw new ValueNotNumericalException(i_UserInput);
            }

            return inputLegal;
        }
    }
}
