using CommodityMarketApi.Models.Entities;
using CommodityMarketApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommodityMarketApi.Controllers
{
    public class ProductController
    {
        [HttpGet]
        public IEnumerable<Product> GetData()
        {
            return ProductRepository.GetProducts().ToArray();
        }

        [HttpGet]
        public IEnumerable<Product> GetDataById(int id)
        {
            return ProductRepository.GetProductById(id);
        }
    }
}
