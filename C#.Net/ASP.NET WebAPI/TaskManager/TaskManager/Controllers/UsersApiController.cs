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
    public class UsersApiController : ApiController
    {
        //public async Task<HttpResponseMessage> GetAll()
        //{
        //    IEnumerable<User> User = await UsersAccessAsync.GetAllUsersAsync();
        //    if (User != null)
        //        return Request.CreateResponse(HttpStatusCode.OK, User);
        //    return Request.CreateResponse(HttpStatusCode.OK, "There is no content yet");
        //}
        [HttpGet]
        public async Task<HttpResponseMessage> GetSelected(string User)
        {
            string[] data = User.Split('.');
            User user = await UsersAccessAsync.GetUserAsync(data[0],data[1]);
            if(user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAddOrUpdate ([FromBody]User user)
        {
            bool result = await UsersAccessAsync.AddOrUpdateAsync(user);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, bad request!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete (int ? Id = null)
        {
            bool result = await UsersAccessAsync.DeleteAsync(Id);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
