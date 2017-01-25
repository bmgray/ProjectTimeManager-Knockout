using DataAccess.Dapper_Model_Classes;
using DataAccess.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DatabaseSeeder
    {        
        public void SeedData()
        {
            DataAccess.Managers.EmployeeManager employeeManagerForDatabase =
                new DataAccess.Managers.EmployeeManager();

            DataAccess.Managers.ProjectManager projectManagerForDatabase =
                new DataAccess.Managers.ProjectManager();

            if (!employeeManagerForDatabase.CheckForEmployees())
            {
                var seedEmployees = new List<Employee>()
                {
                    new Employee() { FirstName = "Benjamin", LastName = "Gray", Email = "bmgray@crimson.ua.edu", Position = "Full-Stack Developer"},
                    new Employee() { FirstName = "Hamilton", LastName = "Bromhead", Email = "hbromhead@crimson.ua.edu", Position = "Project Manager"},
                    new Employee() { FirstName = "Anton", LastName = "McKee", Email = "amckee@crimson.ua.edu", Position = "Business Analyst"},
                    new Employee() { FirstName = "JT", LastName = "Ridinger", Email = "jtridinger@crimson.ua.edu", Position = "Back-end Developer"},
                    new Employee() { FirstName = "Kurt", LastName = "McCain", Email = "kmccain@crimson.ua.edu", Position = "Quality Assurance"}
                };

                foreach(var employee in seedEmployees)
                {
                    employeeManagerForDatabase.CreateEmployee(employee);
                }
            }

            if(!projectManagerForDatabase.CheckForProjects())
            {
                var seedProjects = new List<Project>() {
                    new Project() { Name = "Continuum", Description = "Develop a time tracking app for Capstone PDP."},
                    new Project() { Name = "Phoenix", Description = "Implement a Knockout js front-end utilizing an API." },
                    new Project() { Name = "Capstone", Description = "Develop an application utilizing the Dapper micro ORM instead of Entity Framework."},
                };

                foreach(var project in seedProjects)
                {
                    projectManagerForDatabase.CreateProject(project);
                }
            }          
        }
    }
}
