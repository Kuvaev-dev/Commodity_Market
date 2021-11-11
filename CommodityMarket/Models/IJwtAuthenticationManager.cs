using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommodityMarket.Models
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string usrname, string password);
    }
}
