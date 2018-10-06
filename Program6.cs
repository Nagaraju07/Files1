using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamReaderWriterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("Stream.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(123456);
            sw.WriteLine(".NET Batch");
            sw.WriteLine(false);
            sw.WriteLine(Math.PI);
            sw.Flush();
            fs.Close();

            fs = new FileStream("Stream.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
            fs.Close();

            Console.ReadKey();
        }
    }
}
