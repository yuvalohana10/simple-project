using System;
using System.Text;

namespace B21_Ex01_2
{
    public class Program
    {
        const char k_HourglassSign = '*';
        const int k_HourglassHeight = 5;
        static void Main()
        {
            const int k_LevelCounter = 0;
            PrintHourglassRec(k_HourglassHeight, k_LevelCounter);
        }

        public static void PrintHourglassRec(int i_HourglassHeight, int i_CurrentLevel)
        {
            StringBuilder HourglassCurrentLine = BuiltHourglassLine(i_HourglassHeight, i_CurrentLevel);

            if (i_HourglassHeight == 1)
            {
                Console.WriteLine(HourglassCurrentLine);
            }
            else
            {
                Console.WriteLine(HourglassCurrentLine);
                PrintHourglassRec(i_HourglassHeight - 2, i_CurrentLevel + 1);
                Console.WriteLine(HourglassCurrentLine);
            }
        }

        private static StringBuilder BuiltHourglassLine(int i_NumberOfSigns, int i_NumberOfSpaces)
        {
            StringBuilder OutputLine = new StringBuilder();

            OutputLine.Append(' ', i_NumberOfSpaces);
            OutputLine.Append(k_HourglassSign, i_NumberOfSigns);

            return OutputLine;
        }
    }
}
