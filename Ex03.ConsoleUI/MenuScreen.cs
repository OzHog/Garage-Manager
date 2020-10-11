using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex03.ConsoleUI
{
    public class MenuScreen : InputScreen
    {

        protected readonly int r_MinInputOption;
        protected int m_MaxInputOption;
        protected string m_StrOptions;

        public MenuScreen(Type i_eScreenOptions, string i_MassageToDisplay = null) : base(i_MassageToDisplay)
        {
            r_MinInputOption = 1;
            m_StrOptions = createMenuStringFromEnum(i_eScreenOptions, out m_MaxInputOption);
        }

        private static string createMenuStringFromEnum(Type i_eScreenOptions , out int o_MaxInputOption)
        {
            o_MaxInputOption = 0;
            StringBuilder menuStr = new StringBuilder();
            int optionNumber = 1;
            foreach (string screenOption in Enum.GetNames(i_eScreenOptions))
            {
                string eScreenOptionsAsSentence =
                    string.Concat(screenOption.Select(x => Char.IsUpper(x) ? " " + x : x.ToString()));

                eScreenOptionsAsSentence = eScreenOptionsAsSentence.Insert(0, string.Format("{0}.", optionNumber.ToString()));
                menuStr.AppendLine(eScreenOptionsAsSentence);
                optionNumber++;
            }

            o_MaxInputOption = optionNumber - 1;
            return menuStr.ToString();
        }

        public override void Display(out string o_UserInput)
        {
            o_UserInput = null;
            string userInput = null;
            bool legalInput = false;
            ScreenUtils.Clear();
            ScreenUtils.Display(base.m_MassageToDisplay.ToString());
            ScreenUtils.Display(m_StrOptions);

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

            o_UserInput = userInput;
        }

        protected override bool isUserInputLegal(string i_UserInput)
        {
            bool inputLegal = int.TryParse(i_UserInput, out int intInput);

            if(inputLegal)
            {
                inputLegal = intInput <= m_MaxInputOption && intInput >= r_MinInputOption;
                if(!inputLegal)
                {
                    throw new ValueOutOfRangeException(m_MaxInputOption, r_MinInputOption);
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
