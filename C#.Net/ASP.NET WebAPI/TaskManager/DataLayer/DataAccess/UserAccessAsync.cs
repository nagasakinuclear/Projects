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
    public static class UsersAccessAsync
    {
        public static async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (TasksContext context = new TasksContext())
            {
                return await context.Users.ToListAsync();
            }
        }


        public static async Task<User> GetUserAsync(string login,string pas)
        {
            if (login == null || pas == null)
                return null;
            using (TasksContext context = new TasksContext())
            {
                try
                {
                    return await Task.Run(() =>
                    {
                        User user = context.Users.Where(x => x.Login.ToLower() == login.ToLower()).FirstOrDefault();
                        if (user == null || user.Pass != pas)
                            return null;
                        return user;
                    });
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
        }

        public static async Task<bool> AddOrUpdateAsync(User user)
        {
            if (user == null)
                return false;
            return await Task.Run(() =>
            {
                using (TasksContext context = new TasksContext())
                {
                    try
                    {
                        context.Users.AddOrUpdate(user);
                        context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception ex)
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
                User task = await context.Users.FindAsync(Id);
                if (task == null)
                    return false;
                await Task.Run(() => context.Users.Remove(task));
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
