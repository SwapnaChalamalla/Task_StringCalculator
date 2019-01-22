using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator;

namespace StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Please enter the input");
                    string numbers = Console.ReadLine();

                    //Create object and invoke the add method
                    int result = new AddCalculator().Add(numbers);

                    Console.WriteLine("The result is " + " " + result);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
