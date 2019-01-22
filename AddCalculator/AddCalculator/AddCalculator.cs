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
            var nums = new List<int>();
            string strNum = string.Empty;
            var startIndex = -1;
            
            //var list =Enumerable.Range(0, numbers.Length).ToList().ForEach(arg=> Char.IsDigit(numbers[arg]));            

            for (int i = 0; i < numbers.Length; i++)
            {
                if (startIndex < 0 && Char.IsDigit(numbers[i]))
                {
                    startIndex = i;
                }
            }

            if (startIndex >= 0)
            {
                strNum = numbers.Substring(startIndex);                
            }

            int z = 0;
            string strNumbers = strNum.Replace("\\n", ",");
            char[] delimiterChars = { ' ', ',', ';', '\n', '@', '#' };
            List<int> lstNumber = strNumbers.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).Where(x => int.TryParse(x, out z))
                .Select(x => z).ToList();

            return lstNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the input");
            string numbers = Console.ReadLine();

            //Create object and invoke the add method
            int result = new AddCalculator().Add(numbers);

            Console.WriteLine("The result is " + " " + result);
            Console.ReadLine();
        }

    }
}
