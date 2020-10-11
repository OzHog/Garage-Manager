using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public static class ScreenUtils
    {
       public enum eScreen
        {
            MainMenu,
            DisplayLicenseNumbers,
            VehicleActions,
        }

        public static void Display(string i_MassageToDisplay)
        {
            Console.WriteLine(i_MassageToDisplay);
        }

        public static string GetUserInput(string i_InputLabel = ">>")
        {
            Console.Write("{0} ", i_InputLabel);

            return Console.ReadLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Freeze()
        {
            Display("Press Any Key To Continue");
            Console.ReadKey();
        }

    }
}
