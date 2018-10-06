using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace SoapSerializationDemo
{
    [Serializable]
    public class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee() { EmpID = 101, Name = "Robert", Salary = 30000 };
            FileStream fs = new FileStream("Employee.soap", FileMode.Create, FileAccess.Write);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, emp);
            fs.Close();
            Console.WriteLine("Serialization Done");

            fs = new FileStream("Employee.soap", FileMode.Open, FileAccess.Read);
            Employee anotherEmp = (Employee)sf.Deserialize(fs);
            fs.Close();

            Console.WriteLine("Employee ID : " + anotherEmp.EmpID);
            Console.WriteLine("Employee Name : " + anotherEmp.Name);
            Console.WriteLine("Employee Salary : " + anotherEmp.Salary);

            Console.ReadKey();
        }
    }
}
