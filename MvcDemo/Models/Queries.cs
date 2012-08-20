using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public static class Queries
    {
        public static IEnumerable<ShippingAddress> FindLast(this IQueryable<ShippingAddress> addresses, int number)
        {
            return addresses.OrderByDescending(x => x.Id).Take(number).ToList();
        } 
    }
}