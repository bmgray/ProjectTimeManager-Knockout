using Model.WebAppModels.API;
using DataAccess.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Bridges
{
    public class ProjectBridge
    {
        public IEnumerable<ProjectModel> GetAllProjects()
        {
            DataAccess.Managers.ProjectManager projectManagerForDatabase =
                new DataAccess.Managers.ProjectManager();

            var projectsFromDatabase = projectManagerForDatabase.GetProjects();

            List<ProjectModel> projects = new List<ProjectModel>();

            foreach(var project in projectsFromDatabase)
            {
                projects.Add(new ProjectModel() {
                    projectId = project.ProjectId,
                    projectName = project.Name,
                    projectDescription = project.Description
                });
            }

            return projects;
        }

        public bool FindSingleProject(int projectId)
        {
            DataAccess.Managers.ProjectManager projectManagerForDatabase =
                new DataAccess.Managers.ProjectManager();

            return projectManagerForDatabase.FindSingleProject(projectId);
        }

        public ProjectModel GetSingleProject(int projectId)
        {
            DataAccess.Managers.ProjectManager projectManagerForDatabase =
                new DataAccess.Managers.ProjectManager();

            ProjectModel project = new ProjectModel();

            var projectFromDatabase = projectManagerForDatabase.GetSingleProject(projectId);

            if(projectFromDatabase != null)
            {
                project.projectId = projectFromDatabase.ProjectId;
                project.projectName = projectFromDatabase.Name;
                project.projectDescription = projectFromDatabase.Description;
                return project;
            }
            else
            {
                project.projectId = 0;
                project.projectName = "Error: There was an error retrieving the project information.";
                project.projectDescription = "Error: ProjectId passed the FindSingleProject method, however failed in retrieving the record information.";
                return project;
            }
        }
    }
}
