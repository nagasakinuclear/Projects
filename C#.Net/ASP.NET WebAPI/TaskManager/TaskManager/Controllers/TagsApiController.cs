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
    public class TagsApiController : ApiController
    {
        public async Task<HttpResponseMessage> GetAll()
        {
            IEnumerable<Tag> Tag = await TagsAccessAsync.GetAllTagsAsync();
            if (Tag != null)
                return Request.CreateResponse(HttpStatusCode.OK, Tag);
            return Request.CreateResponse(HttpStatusCode.OK, "There is no content yet");
        }
        public async Task<HttpResponseMessage> GetSelected([FromBody] int ? Id = null)
        {
            Tag tag = await TagsAccessAsync.GetTagAsync(Id);
            if(tag == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, tag);
        }
        public async Task<HttpResponseMessage> PostAddOrUpdate ([FromBody] Tag tag)
        {
            bool result = await TagsAccessAsync.AddOrUpdateAsync(tag);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, bad request!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public async Task<HttpResponseMessage> Delete ([FromBody] int ? Id = null)
        {
            bool result = await TagsAccessAsync.DeleteAsync(Id);
            if (!result)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, not found!");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
