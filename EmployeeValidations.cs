using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EMS.Entity;       //Reference to Employee Entity
using EMS.Exception;    //Reference to Employee Exception
using EMS.DAL;          //Reference to Employee Data Access Layer

namespace EMS.BL
{
    /// <summary>
    /// Employee ID : Developer Employee ID
    /// Employee Name : Developer Employee Name
    /// Description : This class will have business logic for employee
    /// Date of Modification : 4th Oct 2018
    /// </summary>
    public class EmployeeValidations
    {
        //Method to validate employee details
        public static bool ValidateEmployee(Employee emp)
        {
            bool isValidated = true;

            StringBuilder message = new StringBuilder();

            try 
            {
                //Checking employee id that it should be 6 digits
                if (emp.EmployeeID < 100000 || emp.EmployeeID > 999999)
                {
                    message.Append("Employee ID should be 6 digits long\n");
                    isValidated = false;
                }

                //Checking employee name
                if (emp.EmployeeName == string.Empty)
                {
                    message.Append("Employee Name should be provided\n");
                    isValidated = false;
                }
                else if(!Regex.IsMatch(emp.EmployeeName, "[A-Z][a-z]{2,}"))
                {
                    message.Append("Employee Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidated = false;
                }

                //Checking Date of Joining
                if (emp.DOJ > DateTime.Now)
                {
                    message.Append("Date of Joining should be less than or equal to Today's date\n");
                    isValidated = false;
                }

                //Checking Age
                int age = DateTime.Now.Year - emp.DOB.Year;
                if (age < 18 || age > 60)
                {
                    message.Append("Date of Birth should be proper so that employee age will be in range from 18 to 60\n");
                    isValidated = false;
                }

                //Checking Salary
                if (emp.Salary < 0)
                {
                    message.Append("Salary should be positive amount\n");
                    isValidated = false;
                }

                //Checking Phone Number
                if (!Regex.IsMatch(emp.Phone, "[7-9][0-9]{9}"))
                {
                    message.Append("Phone number should start with 7 or 8 or 9 and it should have exactly 10 digits\n");
                    isValidated = false;
                }

                //Checking City
                if (emp.City.ToLower() != "pune" && emp.City.ToLower() != "mumbai" && emp.City.ToLower() != "chennai" && emp.City.ToLower() != "hyderabad")
                {
                    message.Append("City should be either Pune or Mumbai or Chennai or Hyderabad\n");
                    isValidated = false;
                }

                if (isValidated == false)
                    throw new EmployeeException(message.ToString());
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return isValidated;
        }

        //Method to add new employee
        public static bool AddEmployee(Employee emp)
        {
            bool isAdded = false;

            try 
            {
                //Validating employee details
                if (ValidateEmployee(emp))
                {
                    //Adding the employee by calling DAL Add method
                    isAdded = EmployeeOperations.AddEmployee(emp);
                }
                else
                    throw new EmployeeException("Please provide valid employee details");
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return isAdded;
        }

        //Method to update employee details
        public static bool UpdateEmployee(Employee emp)
        {
            bool isUpdated = false;

            try
            {
                //Validating employee details
                if (ValidateEmployee(emp))
                {
                    //Updating the employee details by calling DAL Update method
                    isUpdated = EmployeeOperations.UpdateEmployee(emp);
                }
                else
                    throw new EmployeeException("Please provide valid employee details");
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return isUpdated;
        }

        //Method to delete employee details
        public static bool DeleteEmployee(int empID)
        {
            bool isDeleted = false;

            try 
            {
                //Deleting employee by calling delete method of DAL
                isDeleted = EmployeeOperations.DeleteEmployee(empID);
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return isDeleted;
        }

        //Method to search employee
        public static Employee SearchEmployee(int empID)
        {
            Employee emp = null;

            try 
            {
                //Searching employee by calling DAL search method
                emp = EmployeeOperations.SearchEmployee(empID);
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return emp;
        }

        //Method to display all employees
        public static List<Employee> DisplayEmployees()
        {
            List<Employee> empList = null;

            try 
            {
                //displaying employee by calling DAL display method
                empList = EmployeeOperations.DisplayEmployees();
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return empList;
        }

        //Method to serialize employee details
        public static bool SerializeEmployee()
        {
            bool isSerialized = false;

            try 
            {
                //Serializing by calling DAL serialize method
                isSerialized = EmployeeOperations.SerializeEmployee();
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return isSerialized;
        }

        //Method to Deserialize Employee
        public static List<Employee> DeserializeEmployee()
        {
            List<Employee> empList = null;

            try
            {
                //deserializing employee by calling DAL deserialize method
                empList = EmployeeOperations.DeserializeEmployee();
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return empList;
        }
    }
}
