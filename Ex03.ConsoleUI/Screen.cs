using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Screen
    {
        protected StringBuilder m_MassageToDisplay;

        public Screen(string i_MassageToDisplay = null)
        {
            m_MassageToDisplay = new StringBuilder(i_MassageToDisplay ?? "");
        }

        public virtual void Display()
        {
            ScreenUtils.Display(m_MassageToDisplay.ToString());
        }

        public virtual void SetMassageToDisplay(string i_Massage)
        {
            m_MassageToDisplay.Clear();
            m_MassageToDisplay.Append(i_Massage);
        }

    }
}
