using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnonymousMethodDemo
{
    public delegate void AnnonymousDel();
    public delegate void AnnonymousDelParam(int val1, int val2);
    public delegate string AnnonymousDelReturn(string val1, string val2);
    class Program
    {
        public static void Show()
        {
            Console.WriteLine("Show method called using Delegate");
        }

        public static void Add(int num1, int num2)
        {
            Console.WriteLine("Output using Add Method {0} + {1} => {2}", num1, num2, (num1 + num2));
        }

        static void Main(string[] args)
        {
            //AnnonymousDel del1 = new AnnonymousDel(Show);
            AnnonymousDel del1 = Show;
            del1();

            //Annonymous Method
            //AnnonymousDel anDel1 = delegate 
            //{ 
            //    Console.WriteLine("Anonymous Method called using Delegate"); 
            //};

            AnnonymousDel anDel1 = new AnnonymousDel(delegate 
                { 
                    Console.WriteLine("Anonymous Method called using Delegate"); 
                });
            anDel1();

            AnnonymousDelParam anParam = delegate(int num1, int num2) 
            {
                Console.WriteLine("Output using Annonymous Method {0} + {1} => {2}", num1, num2, (num1 + num2));
            };
            anParam(45, 78);

            AnnonymousDelReturn anReturn = delegate(string str1, string str2) 
            {
                return str1 + " " + str2;
            };

            string result = anReturn(".NET", "Batch");
            Console.WriteLine("Output by using Annonyous Method : " + result);

            Console.ReadKey();
        }
    }
}
