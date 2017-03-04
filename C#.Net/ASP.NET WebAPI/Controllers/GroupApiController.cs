using ShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ShopApi.Controllers
{
    public class GroupApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Groups> Get()
        {
            using (ShopContext db = new ShopContext())
            {
                return db.Groups.ToList() ?? null;
            }
        }
        [HttpGet]
        public Groups Get(int ?Id)
        {
            using (ShopContext db = new ShopContext())
            {
                return db.Groups.FirstOrDefault(x => x.Id == Id) ?? null;
            }
        }
        [HttpPost]
        public void Post([FromBody]Groups group)
        {
            string PatternForSrc = @"\D{2,30}";
            string PatternForName = @"\D{2,15}[.img|.jpg]";
            if (Regex.IsMatch(group.Name,PatternForName, RegexOptions.IgnoreCase | RegexOptions.Compiled) &&
                Regex.IsMatch(group.ImgSrc,PatternForSrc, RegexOptions.IgnoreCase | RegexOptions.Compiled) )
                using (ShopContext db = new ShopContext())
                {
                    db.Groups.Add(group);
                    db.SaveChanges();
                }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int ?Id)
        {
            using (ShopContext db = new ShopContext())
            {
                try
                {
                    var group = db.Groups.FirstOrDefault(x => x.Id == Id);
                    if (group == null)
                       throw new Exception("There is no such group");
                    else
                    {
                        db.Groups.Remove(group);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                catch(Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            }
        }
    }
}
