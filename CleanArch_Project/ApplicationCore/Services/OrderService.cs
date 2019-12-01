using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace ApplicationCore.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork   _unitOfWork;
        
       
        
        public OrderService(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;

           
             
        }

       
        
       
        
        public OrderDto GetOrder(int id)
        {
            var Order = _unitOfWork.Orders.GetBy(id);
            return Order.ConvertToOrderDto();
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var Orders = _unitOfWork.Orders.GetAll().ToList();
            return Orders.ConvertToOrderDtos();

           
        }

        //them order
        public void AddOrder(string currentusername,Order Order,List<Item> cart,OrderDetail OrderDetail)
        {
            int customerid = _unitOfWork.Orders.GetIdCurrentUser(currentusername);

            Order.OrderCustomerId = customerid;


            Order.OrderDate = DateTime.Now;

            //add Order

           _unitOfWork.Orders.Add(Order);

            _unitOfWork.Complete(); //save

            //add item
            int orderid = _unitOfWork.Orders.GetOrderId(customerid);

            for (var i = 0; i < cart.Count; i++)
            {


                //them vao bang OrderDetail
                OrderDetail = new OrderDetail();

                OrderDetail.DetailProductId = cart[i].Product.ProductId;
                OrderDetail.DetailOrderId = orderid;  //orderid
                OrderDetail.Quantity = cart[i].Quantity;



                _unitOfWork.OrderDetails.Add(OrderDetail);

            }

            cart.Clear(); //xoa gio hang

            _unitOfWork.Complete();//luu database

            //HttpContext.Session.Remove("cart");//xoa session gio hang

        }

        public void CreateOrder(OrderDto OrderDto)
        {
            var Order = OrderDto.ConvertToOrder();
            _unitOfWork.Orders.Add(Order);

            _unitOfWork.Complete();
        }
       
        public void UpdateOrder(OrderDto OrderDto)
        {
            var Order = _unitOfWork.Orders.GetBy(OrderDto.OrderId);
            if (Order == null) return;

            OrderDto.Map(Order);

            _unitOfWork.Complete();
        }

        public void DeleteOrder(int id)
        {
            var Order = _unitOfWork.Orders.GetBy(id);
            if (Order != null)
            {
                _unitOfWork.Orders.Remove(Order);
                _unitOfWork.Complete();
            }
        }
    }
}