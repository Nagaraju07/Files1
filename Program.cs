using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Entity;       //Reference to Employee Entity
using EMS.Exception;    //Reference to Employee Exception
using EMS.BL;           //Reference to Business Layer

namespace EMS.PL
{
    class Program
    {
        //Method to add new employee
        public static void AddEmployee()
        {
            try 
            {
                Employee emp = new Employee();
                Console.Write("Enter Employee ID : ");
                emp.EmployeeID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name : ");
                emp.EmployeeName = Console.ReadLine();

                Console.Write("Enter Date of Joining : ");
                emp.DOJ = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Date of Birth : ");
                emp.DOB = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Employee Salary : ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Phone Number : ");
                emp.Phone = Console.ReadLine();

                Console.Write("Enter City : ");
                emp.City = Console.ReadLine();

                bool isAdded = EmployeeValidations.AddEmployee(emp);

                if (isAdded)
                {
                    Console.WriteLine("Employee details added successfully");
                }
                else
                    throw new EmployeeException("Employee details not added");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateEmployee()
        {
            try
            {
                Employee emp = new Employee();
                Console.Write("Enter Employee ID to be updated: ");
                emp.EmployeeID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Modified Employee Name : ");
                emp.EmployeeName = Console.ReadLine();

                Console.Write("Enter Modified Date of Joining : ");
                emp.DOJ = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Modified Date of Birth : ");
                emp.DOB = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Modified Employee Salary : ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Modified Phone Number : ");
                emp.Phone = Console.ReadLine();

                Console.Write("Enter Modified City : ");
                emp.City = Console.ReadLine();

                bool isUpdated = EmployeeValidations.UpdateEmployee(emp);

                if (isUpdated)
                {
                    Console.WriteLine("Employee details updated successfully");
                }
                else
                    throw new EmployeeException("Employee details not updated");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteEmployee()
        {
            try 
            {
                int empID;

                Console.Write("Enter Employee ID to be Deleted : ");
                empID = Convert.ToInt32(Console.ReadLine());

                bool isDeleted = EmployeeValidations.DeleteEmployee(empID);

                if (isDeleted)
                {
                    Console.WriteLine("Employee " + empID + " deleted successfully");
                }
                else
                    throw new EmployeeException("Employee " + empID + " not deleted");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SearchEmployee()
        {
            try 
            {
                int empID;

                Console.Write("Enter Employee ID for Search : ");
                empID = Convert.ToInt32(Console.ReadLine());

                Employee emp = EmployeeValidations.SearchEmployee(empID);

                if (emp != null)
                {
                    Console.WriteLine("Employee ID : " + emp.EmployeeID);
                    Console.WriteLine("Employee Name : " + emp.EmployeeName);
                    Console.WriteLine("Date of Joining : " + emp.DOJ);
                    Console.WriteLine("Date of Birth : " + emp.DOB);
                    Console.WriteLine("Employee Salary : " + emp.Salary);
                    Console.WriteLine("Phone Number : " + emp.Phone);
                    Console.WriteLine("Employee City : " + emp.City);
                }
                else
                    throw new EmployeeException("Employee " + empID + " not found");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplayEmployees()
        {
            try 
            {
                List<Employee> empList = EmployeeValidations.DisplayEmployees();

                if (empList != null || empList.Count > 0)
                {
                    Console.WriteLine("***********************************************************************************************************************");
                    Console.WriteLine("Employee ID     Employee Name       Date of Joining    Date of Birth    Salary      Phone Number      City");
                    Console.WriteLine("***********************************************************************************************************************");
                    foreach (Employee emp in empList)
                    {
                        Console.WriteLine(emp.EmployeeID + "\t" + emp.EmployeeName + "\t" + emp.DOJ + "\t" + emp.DOB + "\t" + emp.Salary + "\t" + emp.Phone + "\t" + emp.City);
                    }
                    Console.WriteLine("***********************************************************************************************************************");
                }
                else
                    throw new EmployeeException("Employee Details not available");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SerializeEmployee()
        {
            try 
            {
                bool isSerialized = EmployeeValidations.SerializeEmployee();

                if (isSerialized)
                    Console.WriteLine("Employee Data is Serialized");
                else
                    throw new EmployeeException("Employee Data is not Serialized");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeserializeEmployee()
        {
            try 
            {
                List<Employee> empList = EmployeeValidations.DeserializeEmployee();

                if (empList != null || empList.Count > 0)
                {
                    Console.WriteLine("***********************************************************************************************************************");
                    Console.WriteLine("Employee ID     Employee Name       Date of Joining    Date of Birth    Salary      Phone Number      City");
                    Console.WriteLine("***********************************************************************************************************************");
                    foreach (Employee emp in empList)
                    {
                        Console.WriteLine(emp.EmployeeID + "\t" + emp.EmployeeName + "\t" + emp.DOJ + "\t" + emp.DOB + "\t" + emp.Salary + "\t" + emp.Phone + "\t" + emp.City);
                    }
                    Console.WriteLine("***********************************************************************************************************************");
                }
                else
                    throw new EmployeeException("Employee Details not deserialized");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Search Employee");
            Console.WriteLine("5. Display Employee");
            Console.WriteLine("6. Serialize Employee");
            Console.WriteLine("7. Deseialize Employee");
            Console.WriteLine("8. Exit");
            Console.WriteLine("----------------------------");
        }
        static void Main(string[] args)
        {
            try 
            {
                int choice;

                do
                {
                    PrintMenu();
                    Console.Write("Enter your choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddEmployee();
                            break;
                        case 2: UpdateEmployee();
                            break;
                        case 3: DeleteEmployee();
                            break;
                        case 4: SearchEmployee();
                            break;
                        case 5: DisplayEmployees();
                            break;
                        case 6: SerializeEmployee();
                            break;
                        case 7: DeserializeEmployee();
                            break;
                        case 8: Environment.Exit(0);
                            break;
                        default: Console.Write("Invalid Choice");
                            break;
                    }
                } while (choice != 8);
            }
            catch(SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
