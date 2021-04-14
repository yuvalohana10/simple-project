using System;

namespace B21_Ex01_5
{
    class Program
    {
        const int k_LengthOfNumberInput = 6;
        public static void Main()
        {
            int k_NumberUserInput;
            string k_ResultMsg;

            k_NumberUserInput = ReadInputFromUser();

            k_ResultMsg = string.Format
                (@"The maximum digit in the number is {0},
The minimum digit in the number is {1},
In the number there are {2} digits that are divided by 3,
In the number there are {3} digits that are bigger then the unity in the number."
, FindTheMaxDigit(k_NumberUserInput), FindTheMinDigit(k_NumberUserInput), FindTheNumberOfDigitsDividedBy3(k_NumberUserInput), FindNumberOfDigitsThatBiggerThenUnity(k_NumberUserInput));

            Console.WriteLine(k_ResultMsg);
        }

        public static int ReadInputFromUser()
        {
            string k_TempStringInput = "";
            int UserInputNumber = 0;
            bool k_IsValidInput = false;

            Console.WriteLine("Please enter a positive number with 6 digits:");

            while (!k_IsValidInput)
            {
                k_TempStringInput = Console.ReadLine();
                k_IsValidInput = (k_TempStringInput.Length == k_LengthOfNumberInput) && (int.TryParse(k_TempStringInput, out UserInputNumber));

                if (!k_IsValidInput)
                {
                    Console.WriteLine("Wrong Input! Please enter a positive number with 6 digits:");
                }
            }
            return UserInputNumber;
        }

        public static int FindTheMaxDigit(int i_NumToCheck)
        {
            int MaxDigit = 0;
            int k_CurrentDigitInNum;

            for (int i = 0; i < k_LengthOfNumberInput; i++)
            {
                k_CurrentDigitInNum = i_NumToCheck % 10;
                if (k_CurrentDigitInNum > MaxDigit)
                {
                    MaxDigit = k_CurrentDigitInNum;
                }
                i_NumToCheck /= 10;
            }

            return MaxDigit;
        }

        public static int FindTheMinDigit(int i_NumToCheck)
        {
            int MinDigit = i_NumToCheck % 10;
            int k_currentDigitInNum;

            for (int i = 0; i < k_LengthOfNumberInput; i++)
            {
                k_currentDigitInNum = i_NumToCheck % 10;
                if (k_currentDigitInNum < MinDigit)
                {
                    MinDigit = k_currentDigitInNum;
                }
                i_NumToCheck /= 10;
            }

            return MinDigit;
        }

        public static int FindTheNumberOfDigitsDividedBy3(int i_NumToCheck)
        {
            int NumOfDigitsDividedBy3 = 0;
            int k_CurrentDigitInNum;

            for (int i = 0; i < k_LengthOfNumberInput; i++)
            {
                k_CurrentDigitInNum = i_NumToCheck % 10;
                if (k_CurrentDigitInNum % 3 == 0)
                {
                    NumOfDigitsDividedBy3++;
                }
                i_NumToCheck /= 10;
            }

            return NumOfDigitsDividedBy3;
        }

        public static int FindNumberOfDigitsThatBiggerThenUnity(int i_NumToCheck)
        {
            int NumOfDigitsBiggerThenUnity = 0;
            int k_UnityDigitInNum = i_NumToCheck % 10;
            int k_CurrentDigitInNum;

            i_NumToCheck /= 10;

            for (int i = 1; i < k_LengthOfNumberInput; i++)
            {
                k_CurrentDigitInNum = i_NumToCheck % 10;
                if (k_CurrentDigitInNum > k_UnityDigitInNum)
                {
                    NumOfDigitsBiggerThenUnity++;
                }
                i_NumToCheck /= 10;
            }

            return NumOfDigitsBiggerThenUnity;
        }
    }
}
