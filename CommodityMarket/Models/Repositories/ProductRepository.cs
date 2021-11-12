using CommodityMarketApi.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CommodityMarketApi.Models.Repositories
{
    public class ProductRepository
    {
        static string connStr = "Data Source = SQL5063.site4now.net; Initial Catalog = db_a7c5be_sellboarddb; User Id = db_a7c5be_sellboarddb_admin; Password=qwerty009";
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (IDbConnection db = new SqlConnection(connStr))
            {
                try
                {
                    db.Open();
                    var query = "EXEC [dbo].[GetProducts]";
                    products = db.Query<Product>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return products;
        }

        public static List<Product> GetProductById(int id)
        {
            List<Product> products = new List<Product>();
            using (IDbConnection db = new SqlConnection(connStr))
            {
                try
                {
                    db.Open();
                    var query = "EXEC [dbo].[GetProductsById] @id";
                    var val = new { id = id };
                    products = db.Query<Product>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return products;
        }
    }
}
