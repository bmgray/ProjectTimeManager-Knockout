using Model.WebAppModels.API;
using DataAccess.Dapper_Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Bridges
{
    public class EmployeeBridge
    {
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            var employeesFromDatabase = employeeManagerForDatabase.GetAllEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var employee in employeesFromDatabase)
            {
                employees.Add(new EmployeeModel()
                {
                    employeeId = employee.Id,
                    firstName = employee.FirstName,
                    lastName = employee.LastName,
                    email = employee.Email,
                    position = employee.Position,
                    dateCreated = employee.DateCreated,
                    lastModified = employee.LastModified
                });
            }

            return employees;
        }

        public bool FindEmployee(int employeeId)
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            return employeeManagerForDatabase.FindEmployee(employeeId);
        }

        public EmployeeModel GetSingleEmployee(int employeeId)
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            EmployeeModel employee = new EmployeeModel();

            var employeeFromDatabase = employeeManagerForDatabase.GetSingleEmployee(employeeId);

            if (employeeFromDatabase != null)
            {
                employee.employeeId = employeeFromDatabase.Id;
                employee.firstName = employeeFromDatabase.FirstName;
                employee.lastName = employeeFromDatabase.LastName;
                employee.email = employeeFromDatabase.Email;
                employee.position = employeeFromDatabase.Position;
                employee.dateCreated = employeeFromDatabase.DateCreated;
                employee.lastModified = employeeFromDatabase.LastModified;
                return employee;
            }
            else
            {
                employee.employeeId = 0;
                employee.firstName = "Error: There was an error retrieving the employee information.";
                employee.lastName = "Error: employeeId passed the FindSingleEmployee method, however failed in retrieving the record information.";
                employee.email = "Error: employeeId passed the FindSingleEmployee method, however failed in retrieving the record information.";
                employee.position = "Error: employeeId passed the FindSingleEmployee method, however failed in retrieving the record information.";
                employee.dateCreated = DateTime.Now;
                employee.lastModified = DateTime.Now;
                return employee;
            }
        }

        public int CreateEmployee(EmployeeModel employee)
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            employee = CheckPropertiesInEmployeeModel(employee);

            return employeeManagerForDatabase.CreateEmployee(new Employee()
            {
                FirstName = employee.firstName,
                LastName = employee.lastName,
                Email = employee.email,
                Position = employee.position
            });
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            employee = CheckPropertiesInEmployeeModel(employee);

            return employeeManagerForDatabase.UpdateEmployee(new Employee()
            {
                Id = employee.employeeId,
                FirstName = employee.firstName,
                LastName = employee.lastName,
                Email = employee.email,
                Position = employee.position,
                LastModified = DateTime.Now
            });
        }

        public bool DeleteEmployee(int employeeId)
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            return employeeManagerForDatabase.DeleteEmployee(employeeId);
        }

        public EmployeeModel CheckPropertiesInEmployeeModel(EmployeeModel employee)
        {
            //Removes excess spacing in front and behind the string
            employee.firstName = employee.firstName.Trim();
            employee.lastName = employee.lastName.Trim();
            employee.email = employee.email.Trim();
            employee.position = employee.position.Trim();

            return employee;
        }
    }
}
