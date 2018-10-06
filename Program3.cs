using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName;

            Console.Write("Enter Directory Name with Full Path : ");
            dirName = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(dirName);

            if (dir.Exists)
            {
                Console.WriteLine("Name : " + dir.Name);
                Console.WriteLine("Creation Time : " + dir.CreationTime);
                Console.WriteLine("Extension : " + dir.Extension);
                Console.WriteLine("Full Name : " + dir.FullName);
                Console.WriteLine("Last Access Time : " + dir.LastAccessTime);
                Console.WriteLine("Last Write Time : " + dir.LastWriteTime);
                Console.WriteLine("Parent : " + dir.Parent);
                Console.WriteLine("Root : " + dir.Root);

                DirectoryInfo[] subDir = dir.GetDirectories();
                Console.WriteLine("Number of Sub Directories : " + subDir.Length);
                for (int i = 0; i < subDir.Length; i++)
                {
                    Console.WriteLine(subDir[i].Name);
                }

                FileInfo[] files = dir.GetFiles();
                Console.WriteLine("\nNumber of Files : " + files.Length);
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(files[i].Name);
                }
            }
            else
            {
                Console.WriteLine(dirName + " does not exists");
            }

            Console.ReadKey();
        }
    }
}
