using CommodityMarketApi.Models.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CommodityMarketApi.Models.Repositories
{
    public class ProductRepository
    {
        private static ILogger<ProductRepository> _logger;
        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }

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
                    _logger.LogInformation($"Get data has been accesed {DateTime.Now}");
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
                    _logger.LogInformation($"Get data has been accesed {DateTime.Now}");
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
