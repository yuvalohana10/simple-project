using System;

namespace B21_Ex01_3
{
    class Program
    {
        static void Main()
        {
            PrintHourglassByUserHeight();
        }

        public static void PrintHourglassByUserHeight()
        {
            int k_HourglassHeight = GetUserHeight();

            B21_Ex01_2.Program.PrintHourglassRec(k_HourglassHeight, 0);
        }

        public static int GetUserHeight()
        {
            int hourglassHeight = 0;
            bool k_isValidInput = false;
            string k_UserChoiseStr;

            while (!k_isValidInput)
            {
                Console.WriteLine("Please type the hourglass height: ");
                k_UserChoiseStr = Console.ReadLine();

                k_isValidInput = int.TryParse(k_UserChoiseStr, out hourglassHeight) && (hourglassHeight > 0);

                if (!k_isValidInput)
                {
                    Console.WriteLine("Invalid input! only a positive integer is allowed");
                }
            }

            if (hourglassHeight % 2 == 0)
            {
                hourglassHeight++;
            }
                
            return hourglassHeight;
        }
    }
}
