using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommodityMarketApi.Models.Entities
{
    public class History
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public List<Token> TokenId { get; set; }
        public List<Product> ProductId { get; set; }
    }
}
