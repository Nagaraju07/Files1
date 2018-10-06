using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{
    public delegate void LambdaDel();
    public delegate void LambdaDelParam(int val1, int val2);
    public delegate string LambdaDelReturn(string val1, string val2);
    class Program
    {
        static void Main(string[] args)
        {
            LambdaDel anDel = delegate 
            { Console.WriteLine("Annoymous Method Called"); };
            anDel();

            LambdaDel lDel = () => Console.WriteLine("Lambda Expression Called");
            lDel();

            LambdaDelParam anParam = delegate(int num1, int num2) { };

            LambdaDelParam lParam = (num1, num2) => Console.WriteLine("Output by Lambda Expression {0} + {1} => {2}", num1, num2, (num1 + num2));
            lParam(45, 12);

            //LambdaDelReturn lReturn = (string str1, string str2) => { return str1 + " " + str2; };
            LambdaDelReturn lReturn = (string str1, string str2) => str1 + " " + str2;
            string result = lReturn(".NET", "Batch");
            Console.WriteLine("Output by Lambda Expression : " + result);
            Console.ReadKey();
        }
    }
}
