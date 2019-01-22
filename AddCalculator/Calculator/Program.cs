using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the input");
            string numbers = Console.ReadLine();

            //Create object and invoke the add method
            int result = new CalculatorForAdd().Add(numbers);

            Console.WriteLine("The result is " + " " + result);
            Console.ReadLine();
        }
    }
}
