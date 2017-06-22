using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Access
{
    public static class CustomersAccessAsync
    {
        public static async Task<List<Customers>> GetAllCustomers()
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Customers.ToList();
                }
            });
        }
        public static async Task<Customers> GetCustomer(int? id)
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Customers.FindAsync(id);
                }
            });
        }
        public static bool AddOrUpdateCustomer(Customers Customer)
        {
            if (Customer == null)
                return false;
            using (ShopContext context = new ShopContext())
            {
                try
                {
                    context.Customers.AddOrUpdate(Customer);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
