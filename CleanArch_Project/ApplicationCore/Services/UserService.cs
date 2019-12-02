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
    public class UserService
    {
        private readonly IUnitOfWork   _unitOfWork;
        
       
        
        public UserService(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;

           
             
        }

        //dang ky
        
       
        
        public UserDto GetUser(int id)
        {
            var User = _unitOfWork.Users.GetBy(id);
            return User.ConvertToUserDto();
        }

        public CustomerDto GetCustomer(int id)
        {
            var Customer = _unitOfWork.Customers.GetBy(id);
            return Customer.ConvertToCustomerDto();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var Users = _unitOfWork.Users.GetAll().ToList();
            return Users.ConvertToUserDtos();

           
        }

        //dang nhap

        public User Login(String username,String password)
        {
            var users = _unitOfWork.Users.GetAll().ToList<User>();

            foreach (var item in users)
            {
                if (username == item.UserName && password == item.UserPassword)
                {
                    return item;
                }

            }
            return null;
        }
        //dang ky
        public void dangky(Customer customer,User user)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();

            user.UserCustomerId = customer.CustomerId;
            user.UserPermissionId = 3;

            
                    _unitOfWork.Users.Add(user);
                    _unitOfWork.Complete();
           
            

            
        }

        //kiem tra username ton tai
        public bool tontaiUsername(User user)
        {
            var users = _unitOfWork.Users.GetAll().ToList<User>(); //lay danh sach user
            foreach (var item in users)
            {

                if (user.UserName == item.UserName)
                {
                    return false;
                }
               
            }


            return true;
        }
        //get list productid
        public List<int> GetProductIds(int orderid)
        {
            var list = _unitOfWork.OrderDetails.ListProductId(orderid).ToList<int>();
            return list;
        }
        public void CreateUser(UserDto UserDto)
        {
            var User = UserDto.ConvertToUser();
            _unitOfWork.Users.Add(User);

            _unitOfWork.Complete();
        }
       
        public void UpdateUser(UserDto UserDto)
        {
            var User = _unitOfWork.Users.GetBy(UserDto.UserId);
            if (User == null) return;

            UserDto.Map(User);

            _unitOfWork.Complete();
        }

        public void DeleteUser(int id)
        {
            var User = _unitOfWork.Users.GetBy(id);
            if (User != null)
            {
                _unitOfWork.Users.Remove(User);
                _unitOfWork.Complete();
            }
        }
    }
}