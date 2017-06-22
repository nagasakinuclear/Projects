using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Access
{
    public static class OrdersAccessAsync
    {
        public static async Task<List<Orders>> GetAllOrders()
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Orders.ToList();
                }
            });
        }
        public static async Task<Orders> GetOrder(int? id)
        {
            return await Task.Run(() =>
            {
                using (ShopContext context = new ShopContext())
                {
                    return context.Orders.FindAsync(id);
                }
            });
        }
        public static bool AddOrUpdateOrder(Orders order)
        {
            if (order == null)
                return false;
            using (ShopContext context = new ShopContext())
            {
                try
                {
                    context.Orders.AddOrUpdate(order);
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
