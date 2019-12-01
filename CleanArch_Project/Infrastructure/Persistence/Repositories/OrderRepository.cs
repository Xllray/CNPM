
using System.Linq;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ProductContext context) : base(context)
        {
        }

        

        protected ProductContext ProductContext
        {
            get { return Context as ProductContext; }
        }

        public int GetIdCurrentUser(string username)
        {
            int id = (from t in ProductContext.User
                     where t.UserName == username
                     select t.UserCustomerId).First<int>(); 

            return id;
        }

        public int GetOrderId(int customerid)
        {
            var orderid = (from t in ProductContext.Order
                           where t.OrderCustomerId == customerid
                           select t.OrderId).ToList<int>();

            

            return orderid[orderid.Count-1];
        }
    }
}