using Dapper;
using DataAccess.Dapper_Model_Classes;
using Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class ProjectManager : _ManagerBase
    {
        public bool CheckForProjects()
        {
            var check = _sqlConnection.Query<Project>("SELECT * FROM Project").Any();
            return check;
        }

        public IEnumerable<Project> GetProjects()
        {
            return _sqlConnection.Query<Project>("SELECT * FROM Project").ToList();
        }

        public bool FindSingleProject(int projectId)
        {
            var project = _sqlConnection.Query<Project>("SELECT * FROM Project WHERE ProjectId = @ProjectId", new { ProjectId = projectId }).SingleOrDefault();

            if(project == null)
            {
                return false;
            }

            return true;
        }

        public Project GetSingleProject(int projectId)
        {
            return _sqlConnection.Query<Project>("SELECT * FROM Project WHERE ProjectId = @ProjectId", new { ProjectId = projectId }).SingleOrDefault();
        }

        public int CreateProject(Project project)
        {
            string insertStatement = @"INSERT Project([Name], [Description]) VALUES (@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";

            var employeeId = _sqlConnection.Query<int>(insertStatement, new { Name = project.Name, Description = project.Description }).SingleOrDefault();

            return employeeId;
        }
    }
}
