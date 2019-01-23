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

                var regexMatch = new Regex(@"\-*\d+");

                lstNumber = regexMatch.Matches(numbers).Cast<Match>()
                    .Select(m => m.Value)
                    .Select(int.Parse).ToList();

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

