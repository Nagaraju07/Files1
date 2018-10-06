using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryReaderWriterDemo
{
    class Program2
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"..\..\binary.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(1234556);
            bw.Write(".NET Batch");
            bw.Write(false);
            bw.Write(Math.PI);
            bw.Write('C');
            fs.Close();

            fs = new FileStream(@"..\..\binary.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadBoolean());
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadChar());
            fs.Close();

            Console.ReadKey();
        }
    }
}
