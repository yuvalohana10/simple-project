using System;

namespace B21_Ex01_4
{
    class Program
    {
        const int k_LengthOfStringInput = 10;
        public static void Main()
        {
            string k_StringUserInput;

            k_StringUserInput = ReadInputFromUser();
            PrintIfTheStringIsPalindrom(k_StringUserInput);
            IfNumberPrintIfDividedBy4(k_StringUserInput);
            PrintNumOfUpperCaseCharacters(k_StringUserInput);
        }

        public static string ReadInputFromUser()
        {
            string userInput = "";
            Console.WriteLine("Please enter a string with 10 letters OR 10 numbers :");

            userInput = Console.ReadLine();
            while (!IsValidInput(userInput))
            {
                Console.WriteLine("Wrong Input!please enter a correct formatted string !");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static bool IsValidInput(string i_StringToCheck)
        {
            bool isValidInput;
            bool k_IsNumber;
            int k_StringConvertedToInt = 0;

            isValidInput = i_StringToCheck.Length == k_LengthOfStringInput;
            k_IsNumber = int.TryParse(i_StringToCheck, out k_StringConvertedToInt);
            for (int i = 0; i < i_StringToCheck.Length && isValidInput && !k_IsNumber; i++)
            {
               isValidInput = Char.IsLower(i_StringToCheck[i]) || Char.IsUpper(i_StringToCheck[i]);
            }

            return isValidInput;
        }

        public static void PrintIfTheStringIsPalindrom(string i_UserStringInput)
        {
            if (!IsPalindrome(i_UserStringInput))
            {
                Console.WriteLine("The string you entered isn't a palindrome,");
            }   
            else
            {
                Console.WriteLine("The string you entered is a palindrome,");
            }
        }

        public static bool IsPalindrome(string i_StringToCheck)
        {

            if (i_StringToCheck.Length <= 1)
            {
                return true;
            }
                
            if (i_StringToCheck[0] != i_StringToCheck[i_StringToCheck.Length - 1])
            {
                return false;
            }
            return IsPalindrome(i_StringToCheck.Substring(1, i_StringToCheck.Length - 2));

        }

        public static void IfNumberPrintIfDividedBy4(string i_StringToCheck)
        {
            int k_StringConvertedToInt = 0;

            if (int.TryParse(i_StringToCheck, out k_StringConvertedToInt))
            {
                if (k_StringConvertedToInt % 4 == 0)
                {
                    Console.WriteLine("The number in the string is divided by 4.");
                }
                else
                {
                    Console.WriteLine("The number in the string is NOT divided by 4.");
                } 
            }
        }

        public static void PrintNumOfUpperCaseCharacters(string i_StringUserInput)
        {
            int k_NumOfUpperCaseCharsInString = 0;
            int k_StringConvertedToInt = 0;
            string k_ResultMsg;

            if (!int.TryParse(i_StringUserInput, out k_StringConvertedToInt))
            {
                for (int i = 0; i < i_StringUserInput.Length; i++)
                {
                    if (char.IsUpper(i_StringUserInput[i]))
                    {
                        k_NumOfUpperCaseCharsInString++;
                    }
                }
            }

            k_ResultMsg = string.Format("The number of upperCase letters in the string is {0}", k_NumOfUpperCaseCharsInString);
            Console.WriteLine(k_ResultMsg);
        }
    }
}
