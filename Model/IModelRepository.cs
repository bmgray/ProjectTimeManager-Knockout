using Model.WebAppModels.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModelRepository
    {
        //PROJECT
        IEnumerable<ProjectModel> ListProjects();
        bool FindSingleProject(int projectId);
        ProjectModel GetSingleProject(int projectId);

        //EMPLOYEE
        IEnumerable<EmployeeModel> ListEmployees();
        bool FindEmployee(int employeeId);
        EmployeeModel GetSingleEmployee(int employeeId);
        int CreateEmployee(EmployeeModel employee);
        void UpdateEmployee(EmployeeModel employee);
        bool DeleteEmployee(int employeeId);
    }
}
