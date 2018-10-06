using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Entity;       //Reference for Employee Entity
using EMS.Exception;    //Reference for Employee Exception
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EMS.DAL
{
    /// <summary>
    /// Employee ID : Developer Employee ID
    /// Employee Name : Developer Employee Name
    /// Description : This class will provide CRUD operations for Employee
    /// Date of Modification : 4th Oct 2018
    /// </summary>
    public class EmployeeOperations
    {
        static List<Employee> empList = new List<Employee>();

        //Method to add new employee
        public static bool AddEmployee(Employee emp)
        {
            bool isAdded = false;

            try 
            {
                //Adding employee in the list
                empList.Add(emp);
                isAdded = true;
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch(SystemException ex)
            {
                throw ex;
            }

            return isAdded;
        }

        //Method to update employee information
        public static bool UpdateEmployee(Employee emp)
        {
            bool isUpdated = false;

            try 
            {
                for (int i = 0; i < empList.Count; i++)
                {
                    //Searching employee for modification
                    if (empList[i].EmployeeID == emp.EmployeeID)
                    {
                        //Modifying Employee Details
                        empList[i].EmployeeName = emp.EmployeeName;
                        empList[i].DOJ = emp.DOJ;
                        empList[i].DOB = emp.DOB;
                        empList[i].Salary = emp.Salary;
                        empList[i].Phone = emp.Phone;
                        empList[i].City = emp.City;
                        isUpdated = true;
                    }
                }
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

        //Method to delete particular Employee
        public static bool DeleteEmployee(int empID)
        {
            bool isDeleted = false;

            try 
            {
                //Searching the employee for delete
                Employee emp = empList.Find(e=>e.EmployeeID == empID);

                if (emp != null)
                {
                    //Deleting Employee information
                    empList.Remove(emp);
                    isDeleted = true;
                }
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

        //Method to search employee information
        public static Employee SearchEmployee(int empID)
        {
            Employee emp = null;

            try 
            {
                //Searching employee
                emp = empList.Find(e => e.EmployeeID == empID);
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

        //Method to display all employee
        public static List<Employee> DisplayEmployees()
        {
            return empList;
        }

        //Method to Serialize Employee Data
        public static bool SerializeEmployee()
        {
            bool isSerialized = false;

            try 
            {
                //Creating object of stream
                FileStream fs = new FileStream("Employee.txt", FileMode.Create, FileAccess.Write);
                //Creating BinaryFormatter object
                BinaryFormatter bin = new BinaryFormatter();
                //Serializing employee data in stream
                bin.Serialize(fs, empList);
                fs.Close();
                isSerialized = true;
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

        //Method to deserialize employee details
        public static List<Employee> DeserializeEmployee()
        {
            List<Employee> empDesList = null;

            try
            {
                //Creating object of stream
                FileStream fs = new FileStream("Employee.txt", FileMode.Open, FileAccess.Read);
                //Creating BinaryFormatter object
                BinaryFormatter bin = new BinaryFormatter();
                //Deserializing employee data from stream
                empDesList = (List<Employee>)bin.Deserialize(fs);
                fs.Close();
            }
            catch (EmployeeException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return empDesList;
        }
    }
}
