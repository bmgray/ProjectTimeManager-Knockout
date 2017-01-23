using Dapper;
using DataAccess.Dapper_Model_Classes;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Managers
{
    public class EmployeeManager : _ManagerBase
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _sqlConnection.Query<Employee>("SELECT * FROM Employee").ToList();
        }

        public bool FindEmployee(int employeeId)
        {
            var employee = _sqlConnection.Query<Employee>("SELECT * FROM Employee WHERE Id = @Id", new { Id = employeeId }).SingleOrDefault();

            if (employee == null)
            {
                return false;
            }

            return true;
        }

        public Employee GetSingleEmployee(int employeeId)
        {
            return _sqlConnection.Query<Employee>("SELECT * FROM Employee WHERE Id = @Id", new { Id = employeeId }).SingleOrDefault();
        }

        public int CreateEmployee(Employee employee)
        {
            string insertStatement = @"INSERT Employee([FirstName], [LastName], [Email], [Position]) VALUES (@FirstName, @LastName, @Email, @Position); SELECT CAST(SCOPE_IDENTITY() as int)";

            var employeeId = _sqlConnection.Query<int>(insertStatement, new { FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email, Position = employee.Position }).SingleOrDefault();

            return employeeId;
        }

        public bool DeleteEmployee(int employeeId)
        {
            var affectedRows = _sqlConnection.Execute("DELETE FROM Employee Where Id = @Id", new { Id = employeeId });

            if(affectedRows > 0)
            {
                return true;
            }

            return false;
        }

        public void UpdateEmployee(Employee employee)
        {
            string updateStatement = @"UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Position = @Position WHERE Id = @Id";

            _sqlConnection.Execute(updateStatement, new { FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email, Position = employee.Position });
        }

    }
}
