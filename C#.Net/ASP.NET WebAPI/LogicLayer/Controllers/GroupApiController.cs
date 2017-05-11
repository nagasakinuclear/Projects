using ShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using DataLayer.Access;
namespace ShopApi.Controllers
{
    public class GroupApiController : ApiController
    {

        public IEnumerable<Group> GetGroups()
        {
            return AccessClass.Get_Groups();
        }

        public Group GetGroup(int ?Id)
        {
            return AccessClass.Get_Group(Id);
        }

        public HttpResponseMessage PostAddGroup([FromBody]Groups group)
        {
            //Regex checking in model
            try
            {
                if (ModelState.IsValid)
                {
                    AccessClass.Add_Group(group);
                }
                throw new Exception("Ошибка при вводе данных");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public HttpResponseMessage DeleteGroup(int ?Id)
        {
            return AccessLayer.Delete_Group(Id);
        }

    }
}
