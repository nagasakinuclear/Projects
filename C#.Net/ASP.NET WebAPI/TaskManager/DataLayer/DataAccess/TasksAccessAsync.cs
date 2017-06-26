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
    public static class TasksAccessAsync
    {
        public static async Task<IEnumerable<Tasks>> GetAllTasksAsync(int  UserId)
        {
                using (TasksContext context = new TasksContext())
                {
                    return await context.Tasks.Where(x=>x.UserId == UserId).ToListAsync();
                }
        }


        public static async Task<Tasks> GetTaskAsync(int? Id)
        {
                using (TasksContext context = new TasksContext())
                {
                    return await context.Tasks.FindAsync(Id);
                }
        }

        public static async Task<bool> AddOrUpdateAsync(Tasks task)
        {
            return await Task.Run(() =>
            {
                if (task == null)
                    return false;
                using (TasksContext context = new TasksContext())
                {
                    try
                    {
                        context.Tasks.AddOrUpdate(task);
                        context.SaveChangesAsync();
                        return true;
                    }
                    catch(Exception)
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
                    Tasks task = await context.Tasks.FindAsync(Id);
                    if (task == null)
                        return false;
                    await Task.Run(()=> context.Tasks.Remove(task));
                    await context.SaveChangesAsync();
                    return true;
                }
        }
    }
}
