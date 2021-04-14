using System;

namespace B21_Ex01_1
{
    class Program
    {
        const int k_DecimalBase = 10;
        const int k_BinaryBase = 2;
        const int k_NumOfBits = 7;
        const int k_NumOfNumbersToRead = 3;

        static void Main()
        {
            int[] binaryNumbersArray = new int[k_NumOfNumbersToRead];

            ReadBinaryNumbersFromUser(binaryNumbersArray, k_NumOfNumbersToRead, k_NumOfBits);
            PrintNumbersInDecimalBase(binaryNumbersArray, k_NumOfNumbersToRead, k_NumOfBits);
            PrintAverageBinaryDigits(binaryNumbersArray,k_NumOfNumbersToRead, k_NumOfBits);
            PrintNumberOfPowerOfTwoNumbers(binaryNumbersArray, k_NumOfBits);
            PrintNumberOfNumbersInAscendingOrder(binaryNumbersArray, k_NumOfBits);
            PrintMaxAndMinNumbers(binaryNumbersArray, k_NumOfBits);
        }


        public static void ReadBinaryNumbersFromUser(int[] i_BinaryNumbersArr, int i_BinaryNumbersToRead, int i_NumOfBitsInEachNumber)
        {
            string currentStringInput;
            int k_BinaryNumberArrIndex = 0;
            string inputMessage = string.Format("Please enter {0} binary numbers, with {1} digits each:", i_BinaryNumbersToRead, i_NumOfBitsInEachNumber);
            string errorMessage = string.Format("You entered a wrong input. Only binary numbers with {0} digits are allowed.", i_NumOfBitsInEachNumber);

            Console.WriteLine(inputMessage);
            while (k_BinaryNumberArrIndex < i_BinaryNumbersToRead)
            {
                currentStringInput = Console.ReadLine();

                if (IsValidInput(currentStringInput, i_NumOfBitsInEachNumber))
                {
                    i_BinaryNumbersArr[k_BinaryNumberArrIndex] = int.Parse(currentStringInput);
                    k_BinaryNumberArrIndex++;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

      public static bool IsValidInput(string i_StringToCheck, int i_NumOfBitsInANumber)
        {
            bool isValidInput = true;
            int k_CurrentDigit;

            if (i_NumOfBitsInANumber == i_StringToCheck.Length)
            {
                for (int i = 0; (i < i_NumOfBitsInANumber) && isValidInput; i++)
                {
                    k_CurrentDigit = i_StringToCheck[i];
                    if (k_CurrentDigit != '0' && k_CurrentDigit != '1')
                    {
                        isValidInput = false;
                    }
                }
            }
            else
            {
                isValidInput = false;
            }
              
            return isValidInput;
        }

        public static void PrintNumbersInDecimalBase(int [] i_BinaryNumbersArr, int i_NumONumbersToRead, int i_NumOfBitsInANumber)
        {
            int k_DecimalNumber;
            string k_NumberToPrint;

            Console.Write("The numbers in decimal base are: ");

            for (int i=0; i < i_NumONumbersToRead; i++)
            {
               k_DecimalNumber = ConvertFromBinaryToDecimal(i_BinaryNumbersArr[i], i_NumOfBitsInANumber);
               k_NumberToPrint = string.Format("{0}, ", k_DecimalNumber);
               Console.Write(k_NumberToPrint);
            }

            Console.WriteLine();
        }

        public static int ConvertFromBinaryToDecimal(int i_BinaryNumberToConvert, int i_NumOfBitsInANumber)
        {
            int k_CurrentDigit;
            int convertedNumber = 0;

            for (int i = 0; i < i_NumOfBitsInANumber; i++)
            {
                k_CurrentDigit = i_BinaryNumberToConvert % k_DecimalBase;
                i_BinaryNumberToConvert /= k_DecimalBase;
                convertedNumber += k_CurrentDigit * (int)Math.Pow(k_BinaryBase, i);
            }

            return convertedNumber;
        }

        public static void PrintAverageBinaryDigits(int [] i_BinaryNumbersArray,int i_NumOfNumbersToRead, int i_NumOfBitsInANumber)
        {
            int k_TotalZeros = 0, k_TotalOnes = 0;
            float k_AverageZeros, k_AverageOnes;
            string k_AverageResultMsgToPrint;

            for (int i = 0; i < i_NumOfNumbersToRead; i++)
            {
                k_TotalZeros += CountDigitInANumber(i_BinaryNumbersArray[i],i_NumOfBitsInANumber, 0);
                k_TotalOnes += CountDigitInANumber(i_BinaryNumbersArray[i],i_NumOfBitsInANumber, 1);
            }

            k_AverageZeros = (float)k_TotalZeros / i_NumOfNumbersToRead;
            k_AverageOnes = (float)k_TotalOnes / i_NumOfNumbersToRead;

            k_AverageResultMsgToPrint = string.Format("The average number of zeros is {0}, and the average number of ones is {1},", k_AverageZeros, k_AverageOnes);
            Console.WriteLine(k_AverageResultMsgToPrint);
        }

        public static int CountDigitInANumber(int i_NumberToCheck,int i_NumOfBitsInANumber, int i_NumberToCount)
        {
            int k_TempNumberToCheck = i_NumberToCheck;
            int NumberToCheckCounter = 0;
 
            for(int k_NumberOfBitsIndex=0; k_NumberOfBitsIndex< i_NumOfBitsInANumber; k_NumberOfBitsIndex++)
            {
                if (k_TempNumberToCheck % 10 == i_NumberToCount)
                {
                    NumberToCheckCounter++;
                }

                k_TempNumberToCheck /= 10;
            }

            return NumberToCheckCounter;
        }

        public static void PrintNumberOfPowerOfTwoNumbers(int[] i_BinaryNumbersArray, int i_NumberOfBits)
        {
            int k_TotalNumberOfOnes = 0, k_TotalNumberOfPowersOfTwo = 0;
            string ResultMessage;

            for (int i = 0; i < i_BinaryNumbersArray.Length; i++)
            {
                k_TotalNumberOfOnes = CountDigitInANumber(i_BinaryNumbersArray[i], i_NumberOfBits, 1);
                if (k_TotalNumberOfOnes == 1)
                {
                    k_TotalNumberOfPowersOfTwo++;
                }
            }

            ResultMessage = string.Format("The number of numbers which are a power of 2 is: {0}.", k_TotalNumberOfPowersOfTwo);
            Console.WriteLine(ResultMessage);
        }

       public static void PrintNumberOfNumbersInAscendingOrder(int[] i_BinaryNumbersArray, int i_NumOfBits)
        {
            bool isInAscendingOrder;
            int k_AscendingOrderNumbersCounter = 0;
            string resultMessage;

            for (int i = 0; i < i_BinaryNumbersArray.Length; i++)
            {
                isInAscendingOrder = CheckIfNumberIsInAscendingOrder(i_BinaryNumbersArray[i], i_NumOfBits);

                if (isInAscendingOrder)
                {
                    k_AscendingOrderNumbersCounter++;
                }    
            }

            resultMessage = string.Format("The number of numbers that their digits in decimal are in ascending order is: {0}.", k_AscendingOrderNumbersCounter);
            Console.WriteLine(resultMessage);
        }
      
        public static bool CheckIfNumberIsInAscendingOrder(int i_NumberToCheck, int i_NumOfBits)
        {
            bool isNumberIsInAscendingOrder = true;
            int k_NumberToCheckInDecimal;
            int k_CurrentDigitInNumberToCheck;
            int k_NextDigitInNumberToCheck;

            k_NumberToCheckInDecimal = ConvertFromBinaryToDecimal(i_NumberToCheck, i_NumOfBits);
            
            while(k_NumberToCheckInDecimal > 0 && isNumberIsInAscendingOrder)
            {
                k_CurrentDigitInNumberToCheck = k_NumberToCheckInDecimal % k_DecimalBase;
                k_NumberToCheckInDecimal /= k_DecimalBase;
                k_NextDigitInNumberToCheck = k_NumberToCheckInDecimal % k_DecimalBase;
                isNumberIsInAscendingOrder = k_CurrentDigitInNumberToCheck > k_NextDigitInNumberToCheck;
            }

            return isNumberIsInAscendingOrder;
        }

        public static void PrintMaxAndMinNumbers(int [] i_BinaryNumbersArray, int i_NumOfBits)
        {
            int k_MaxNumberInTheArray = ConvertFromBinaryToDecimal(i_BinaryNumbersArray[0], i_NumOfBits);
            int k_MinNumberInTheArray = ConvertFromBinaryToDecimal(i_BinaryNumbersArray[0], i_NumOfBits);
            int k_CurrentNumber;
            string resultMessage;

            for (int i=1; i< i_BinaryNumbersArray.Length; i++)
            {
                k_CurrentNumber = ConvertFromBinaryToDecimal(i_BinaryNumbersArray[i], i_NumOfBits);
                if (k_CurrentNumber > k_MaxNumberInTheArray)
                {
                    k_MaxNumberInTheArray = k_CurrentNumber;
                }
                if (k_CurrentNumber < k_MinNumberInTheArray)
                {
                    k_MinNumberInTheArray = k_CurrentNumber;
                }
            }

            resultMessage = string.Format("The maximum number is {0}, and the minimum number is {1}.", k_MaxNumberInTheArray, k_MinNumberInTheArray);
            Console.WriteLine(resultMessage);
        }
    }
}

