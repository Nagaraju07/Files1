using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entity
{
    /// <summary>
    /// Employee ID : Developers Employee ID
    /// Employee Name : Developers Employee Name
    /// Description : This is an Entity Class for Employee
    /// Date of Modification : 4th Oct 2018
    /// </summary>
    [Serializable]
    public class Employee
    {
        //Get or Set Employee ID
        public int EmployeeID { get; set; }

        //Get or Set Employee Name
        public string EmployeeName { get; set; }

        //Get or Set Date of Joining
        public DateTime DOJ { get; set; }

        //Get or Set Date of Birth
        public DateTime DOB { get; set; }

        //Get or Set Salary
        public double Salary { get; set; }

        //Get or Set Phone Number
        public string Phone { get; set; }

        //Get or Set City
        public string City { get; set; }
    }
}
