using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        int GetIdCurrentUser(string username);


        int GetOrderId(int customerid);
    }
}