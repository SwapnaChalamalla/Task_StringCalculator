using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AddCalculator
    {
        /// <summary>
        /// Seperates numbers from string and make sum
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Add(string numbers)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrEmpty(numbers))
                {
                    //Seperate numbers from string 
                    var lstNumbers = GetNumbersfromString(numbers);

                    result = lstNumbers.Sum();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Seperates the numbers from string and converts to list
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> GetNumbersfromString(string numbers)
        {
            try
            {
                var lstNumber = new List<int>();
                string strNum = string.Empty;

                int startIndex = GetIndexOfFirstNumber(numbers);

                if (startIndex >= 0)
                    strNum = numbers.Substring(startIndex);

                int z = 0;
                string strNumbers = strNum.Replace("\\n", ",");
                char[] delimiterChars = { ' ', ',', ';', '\n', '@', '#' ,'$'};
                lstNumber = strNumbers.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).Where(x => int.TryParse(x, out z))
                    .Select(x => z).ToList();

                //Check where numbers are positive or negative
                ValidateNumbersArePositive(lstNumber);
                return lstNumber;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Gets index number of first digit
        /// </summary>
        /// <param name="numbers"></param>        
        /// <returns></returns>
        public static int GetIndexOfFirstNumber(string numbers)
        {
            var startIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (startIndex < 0 && Char.IsDigit(numbers[i]))
                {
                    startIndex = i;
                }
            }
            return startIndex;
        }

        /// <summary>
        /// Validates if any negative numbers are present in the list
        /// </summary>
        /// <param name="numbersList">ex:1,-2,3</param>
        public static void ValidateNumbersArePositive(List<int> numbersList)
        {
            if (numbersList.Any(x => x < 0))
            {
                var negativeNumbers = string.Join(",", numbersList.Where(x => x < 0).Select(x => x.ToString()).ToArray());
                throw new System.Exception("negatives not allowed " + " " + negativeNumbers);
            }

        }
    }
}

