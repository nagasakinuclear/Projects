using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Access
{
        public static class ProductsAccessAsync
        {
            public static async Task<List<Products>> GetAllProducts()
            {
                return await Task.Run(() =>
                {
                    using (ShopContext context = new ShopContext())
                    {
                        return context.Products.ToList();
                    }
                });
                
            }

            public static async Task<Products> GetProduct(int? id)
            {
                return await Task.Run(() =>
                {
                    using (ShopContext context = new ShopContext())
                    {
                        return context.Products.FindAsync(id);
                    }
                });
            }

            public static bool AddOrUpdateProduct(Products product)
            {
                if (product == null)
                    return false;
                using (ShopContext context = new ShopContext())
                {
                    try
                    {
                        context.Products.AddOrUpdate(product);
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

