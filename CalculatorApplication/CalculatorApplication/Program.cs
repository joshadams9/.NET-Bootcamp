using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    //obtains two decimal values
    //takes users values and and does a math operation with them
    //calculates the results 
    // prints out the results




    class Program
    {
        static void Main(string[] args)
        {

            decimal firstNum;
            decimal secondNum;                   //Variables for equation
            string operation;
            decimal answer;

            Console.WriteLine("Hello, welcome to Josh's basic calculator!");
            Console.ReadLine();
            //inputs first value 
            Console.Write("Enter the first number in your basic equation: ");
            firstNum = Convert.ToDecimal(Console.ReadLine());

            //User second value 
            Console.Write("Now enter your second number in the basic equation: ");
            secondNum = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ok now enter your operation ( x , / , +, -) ");
            operation = Console.ReadLine();

            if (operation == "x")
            {
                answer = firstNum * secondNum;
                Console.WriteLine(firstNum + " x " + secondNum + " = " + answer);
                Console.ReadLine();
            }
            else if (operation == "/")
            {
                answer = firstNum / secondNum;
                Console.WriteLine(firstNum + " / " + secondNum + " = " + answer);
                Console.ReadLine();
            }
            //Getting answers
            else if (operation == "+")
            {
                answer = firstNum + secondNum;
                Console.WriteLine(firstNum + " + " + secondNum + " = " + answer);
                Console.ReadLine();
            }
            else if (operation == "-")
            {
                answer = firstNum - secondNum;
                Console.WriteLine(firstNum + " - " + secondNum + " = " + answer);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry that is not correct format! Please restart!");     //Catch
                Console.ReadLine();


            }


        }
    }
}
