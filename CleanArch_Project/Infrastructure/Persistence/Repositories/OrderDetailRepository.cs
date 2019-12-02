
using System.Linq;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ProductContext context) : base(context)
        {
        }

        

        protected ProductContext ProductContext
        {
            get { return Context as ProductContext; }
        }

       

        public int GetOrderDetailId(int OrderId)
        {
           int orderDetailId= (from t in ProductContext.OrderDetail
                               where t.DetailOrderId == OrderId
                               select t.OrderDetailId).First<int>();
            return orderDetailId;
        }

        public IEnumerable<int> ListProductId(int OrderId)
        {
            var ProductIds = (from o in ProductContext.OrderDetail
                              where o.DetailOrderId == OrderId
                              select o.DetailProductId);

            return ProductIds.Distinct().ToList();

        }
    }
}