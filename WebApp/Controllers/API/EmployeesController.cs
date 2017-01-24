using DataBridge;
using Model;
using System.Web.Http;
using Model.WebAppModels.API;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Net;
using System.Net.Http;
using System.Linq;

namespace WebApp.Controllers.API
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        IModelRepository _repo;

        public EmployeesController()
        {
            // This would be replaced by nInject or another dependency injector, if implemented.
            // We are simply hand-coding this in each Controller. 
            _repo = new DataBridgeModelRepository();
        }

        [Route("")]
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            var employees = _repo.ListEmployees();

            return employees;
        }

        [Route("id/{employeeId:int}")]
        [ResponseType(typeof(EmployeeModel))]
        public IHttpActionResult GetSingleEmployee(int employeeId)
        {
            if (_repo.FindEmployee(employeeId) == false)
            {
                return NotFound();
            }

            return Ok(_repo.GetSingleEmployee(employeeId));
        }

        [Route("create")]
        public HttpResponseMessage CreateEmployee([FromBody] EmployeeModel employee)
        {
            if(employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read data from body.");

            }

            if (!ModelState.IsValid)
            {
                string modelStateError = "The model state is invalid: ";
                modelStateError += string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) + ".";

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelStateError);
            }
            
            int employeeId = _repo.CreateEmployee(employee);

            if(employeeId == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, employeeId);
            }
        }

        [Route("delete/id/{employeeId:int}")]
        public HttpResponseMessage DeleteEmployee(int employeeId)
        {
            if (_repo.FindEmployee(employeeId) == false)
            {
               return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee could not be found using the passed employeeId.");
            }

            var deletedRecordBoolean = _repo.DeleteEmployee(employeeId);

            if(deletedRecordBoolean == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee record was not deleted using the passed employeeId.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "The employee has been deleted (employeeId: " + employeeId + ").");
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateEmployee([FromBody] EmployeeModel employee)
        {
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read data from body.");
            }

            if (!ModelState.IsValid)
            {
                string modelStateError = "The model state is invalid: ";
                modelStateError += string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) + ".";

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelStateError);
            }

            if (_repo.FindEmployee(employee.employeeId) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee could not be found using the passed employeeId.");
            }

            //update
            _repo.UpdateEmployee(employee);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
