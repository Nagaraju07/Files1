using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Exception
{
    /// <summary>
    /// Employee ID : Developer Employee ID
    /// Employee Name : Developer Employee Name
    /// Descrition : This is an user defined exception class for an Employee
    /// Date of Modification : 4th Oct 2018
    /// </summary>
    public class EmployeeException : ApplicationException
    {
        //Default Constructor
        public EmployeeException()
            : base()
        { }

        //Parameterized constructor with message parameter
        public EmployeeException(string message)
            : base(message)
        { }
    }
}
