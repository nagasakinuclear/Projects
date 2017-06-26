using DataLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataAccess
{
    public static class TagsAccessAsync {
        public static async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            using (TasksContext context = new TasksContext())
            {
                return await context.Tags.ToListAsync();
            }
        }


        public static async Task<Tag> GetTagAsync(int? Id)
        {
            using (TasksContext context = new TasksContext())
            {
                return await context.Tags.FindAsync(Id);
            }
        }

        public static async Task<bool> AddOrUpdateAsync(Tag task)
        {
            return await Task.Run(() =>
            {
                if (task == null)
                    return false;
                using (TasksContext context = new TasksContext())
                {
                    try
                    {
                        context.Tags.AddOrUpdate(task);
                        context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            });
        }
        public static async Task<bool> DeleteAsync(int? Id = null)
        {
            if (Id == null)
                return false;
            using (TasksContext context = new TasksContext())
            {
                Tag task = await context.Tags.FindAsync(Id);
                if (task == null)
                    return false;
                await Task.Run(() => context.Tags.Remove(task));
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}

