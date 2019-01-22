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

            int result = 0;
            if (!string.IsNullOrEmpty(numbers))
            {
                //Seperate numbers from string 
                var lstNumbers = GetNumbersfromString(numbers);

                result = lstNumbers.Sum();
            }
            return result;
        }


        /// <summary>
        /// Seperates the numbers from string and converts to list
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> GetNumbersfromString(string numbers)
        {
            var lstNumber = new List<int>();
            string strNum = string.Empty;

            int y = 0;
            lstNumber = Regex.Split(numbers, @"\D+")
                .Where(x => int.TryParse(x, out y))
                .Select(x => y).ToList();
            return lstNumber;
        }



    }
}

