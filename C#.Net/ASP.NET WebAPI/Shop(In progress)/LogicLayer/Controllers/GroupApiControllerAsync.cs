using ShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using DataLayer.Access;
using System.Threading.Tasks;
using DataLayer.Model;

namespace ShopApi.Controllers
{
    public class GroupApiControllerAsync : ApiController
    {

        public async Task<HttpResponseMessage> GetGroupsAsync()
        {
            List<Groups> GroupsList = GroupsAccessAsync.GetAllGroups().Result;
            if (GroupsList == null)
                return await Task.Run(() => Request.CreateResponse(HttpStatusCode.NotFound, "There is no groups"));
            return await Task.Run(()=>Request.CreateResponse(HttpStatusCode.OK, GroupsList));
        }

        public async Task<HttpResponseMessage> GetGroupAsync([FromBody]int ?Id)
        {
            Groups group = GroupsAccessAsync.GetGroup(Id).Result;
            if(group == null)
                return await Task.Run(() => Request.CreateResponse(HttpStatusCode.NotFound, $"There is no group with Id - {Id}" ));
            return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK, group));
        }

        public async Task<HttpResponseMessage> PostAddGroupAsync([FromBody]Groups group)
        {
            //Regex checking in model
            try
            {
                if (ModelState.IsValid)
                {
                    GroupsAccessAsync.AddOrUpdateGroup(group);
                }
                else
                {
                    throw new Exception("Ошибка при вводе данных");
                }
            }
            catch (Exception ex)
            {
                return await Task.Run(() => Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
            return await Task.Run(() => Request.CreateResponse(HttpStatusCode.OK, "Group Added"));
        }

    }
}
