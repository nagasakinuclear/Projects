using DataLayer.DataAccess;
using DataLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TaskManager.Controllers
{
    public class TasksApiController : ApiController
    {
        public async Task<HttpResponseMessage> GetAll(int UserId)
        {
            IEnumerable<Tasks> tasks = await TasksAccessAsync.GetAllTasksAsync(UserId);
            if (tasks != null)
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            return Request.CreateResponse(HttpStatusCode.OK, "There is no content yet");
        }
        public async Task<HttpResponseMessage> GetSelected([FromBody] int ? Id = null)
        {
            Tasks task = await TasksAccessAsync.GetTaskAsync(Id);
            if(task == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, task);
        }
        public async Task<HttpResponseMessage> PostAddOrUpdate ([FromBody] Tasks task)
        {
            bool result = await TasksAccessAsync.AddOrUpdateAsync(task);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, bad request!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public async Task<HttpResponseMessage> Delete ([FromBody] int ? Id = null)
        {
            bool result = await TasksAccessAsync.DeleteAsync(Id);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
