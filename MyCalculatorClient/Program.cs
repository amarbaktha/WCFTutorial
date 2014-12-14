using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyCalculatorClient.MathServiceReference;

namespace MyCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MathClient client = new MathClient("NetTcpBinding_IMath");

            Console.WriteLine("Enter X: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine();
            //10
            Console.WriteLine("Add: {0}", client.Add(x));
            Console.WriteLine("Add: {0}", client.Add(x));
            Console.WriteLine("Add: {0}", client.Add(x));
            //30
            Console.WriteLine("Sub: {0}", client.Subtract(x));
            //20
            Console.WriteLine("Multiplication: {0}", client.Multiplication(x));
            //200
            Console.WriteLine("Division: {0}", client.Division(x));
            //20
            Console.WriteLine("Running Total: {0}", client.GetRunningTotal());
            //Console.WriteLine("add: {0}", client.Add(x)); 
            //Console.WriteLine("add: {0}", client.Add(x));



        }
    }
}
