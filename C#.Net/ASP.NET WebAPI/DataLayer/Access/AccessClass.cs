using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Access
{
    public static class AccessClass
    {
        public static IEnumerable<Groups> Get_Groups()
        {
            using (ShopContext db = new ShopContext())
            {
                return db.Groups.ToList();
            }
        }
        public static IGrouping Get_Group(int ? id)
        {
            using (ShopContext db = new ShopContext())
            {
                return db.Groups.FirstOrDefault(x => x.Id == Id);
            }
        }
        public static void Add_Group(Group group)
        {
            using (ShopContext db = new ShopContext())
            {
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }
        public static HttpResponseMessage DeleteGroup(int ? Id)
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
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            }
        }
    }
}
