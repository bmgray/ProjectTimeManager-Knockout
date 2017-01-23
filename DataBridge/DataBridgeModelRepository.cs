using DataBridge.Bridges;
using Model;
using Model.WebAppModels.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge
{
    public class DataBridgeModelRepository : IModelRepository
    {
        #region Project 

        public IEnumerable<ProjectModel> ListProjects()
        {
           return new ProjectBridge().GetAllProjects();
        }

        public bool FindSingleProject(int projectId)
        {
            return new ProjectBridge().FindSingleProject(projectId);
        }

        public ProjectModel GetSingleProject(int projectId)
        {
            return new ProjectBridge().GetSingleProject(projectId);
        }

        #endregion

        #region Employee

        public IEnumerable<EmployeeModel> ListEmployees()
        {
            return new EmployeeBridge().GetAllEmployees();
        }

        public bool FindEmployee(int employeeId)
        {
            return new EmployeeBridge().FindEmployee(employeeId);
        }

        public EmployeeModel GetSingleEmployee(int employeeId)
        {
            return new EmployeeBridge().GetSingleEmployee(employeeId);
        }

        public int CreateEmployee(EmployeeModel employee)
        {
            return new EmployeeBridge().CreateEmployee(employee);
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            new EmployeeBridge().UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return new EmployeeBridge().DeleteEmployee(employeeId);
        }
        #endregion
    }
}
