using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Access
{
    public static class GroupsAccessAsync
    {
        public static async Task<List<Groups>> GetAllGroups()
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Groups.Select
                         (x => new Groups { ImgSrc = x.ImgSrc, Name = x.Name, Id = x.Id }).ToList();
                }
            });
        }
        public static async Task<Groups> GetGroup(int? id)
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Groups.FindAsync(id);
                }
            });
        }
        public static bool AddOrUpdateGroup(Groups group)
        {
            if (group == null)
                return false;
            using (ShopContext context = new ShopContext())
            {
                try
                {
                    context.Groups.AddOrUpdate(group);
                    context.SaveChanges();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

    }
}
