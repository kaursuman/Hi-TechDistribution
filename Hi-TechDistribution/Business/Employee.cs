using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_TechDistribution.DataAccess;

namespace Hi_TechDistribution.Business
{
    public class Employee
    {
            private int employeeId;
            private string firstName;
            private string lastName;
            private string jobTitle;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }
        public List<Employee> GetEmployeeList()
        {
            return (EmployeeDB.GetRecordList());
        }
        public void DeleteEmployee(int empid)
        {
            EmployeeDB.DeleteRecord(empid);
        }
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }
        public Employee SearchEmployee(int empId)
        {
            return (EmployeeDB.SearchRecord(empId));
        }
        public List<Employee> SearchEmployee(string name)
        {
            return (EmployeeDB.SearchRecord(name));
        }
    }
}
