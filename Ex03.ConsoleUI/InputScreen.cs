using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public abstract class InputScreen : Screen
    {
        protected InputScreen(string i_MassageToDisplay = null) : base(i_MassageToDisplay) {}

        protected abstract bool isUserInputLegal(string i_UserInput);

        public virtual void Display(out string o_UserInput)
         { 
             o_UserInput = null;
             bool inputLegal = false;
            string userInput= null;

             ScreenUtils.Clear();
            base.Display();

            while(!inputLegal)
            {
                userInput = ScreenUtils.GetUserInput();
                try
                {
                    inputLegal = isUserInputLegal(userInput);

                }
                catch (Exception exception)
                {
                    ScreenUtils.Display(exception.ToString());
                }
            }

            o_UserInput = userInput;
        }

    }
}
