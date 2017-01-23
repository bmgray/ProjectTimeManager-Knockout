using DataBridge;
using Model;
using Model.WebAppModels.API;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApp.Controllers.API
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        IModelRepository _repo;

        public ProjectsController()
        {
            // This would be replaced by nInject or another dependency injector, if implemented.
            // We are simply hand-coding this in each Controller. 
            _repo = new DataBridgeModelRepository();
        }

        [Route("")]
        public IEnumerable<ProjectModel> GetAllProjects()
        {
            var projects = _repo.ListProjects();

            return projects;
        }

        [Route("id/{projectId:int}")]
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult GetSingleProject(int projectId)
        {
            if(_repo.FindSingleProject(projectId) == false)
            {
                return NotFound();
            }

            return Ok(_repo.GetSingleProject(projectId));
        }
    }
}
