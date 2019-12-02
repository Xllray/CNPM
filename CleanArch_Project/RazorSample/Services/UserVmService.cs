using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;
using System;
using System.Linq.Expressions;
using ApplicationCore.Services;
using ApplicationCore.DTOs;

namespace Web.Services
{
    public class UserVmService 
    {
       
        
        private readonly UserService _service;

        public UserVmService(UserService UserService)
        {
            _service = UserService;
        }
        public UserVm GetUserViewModel(int id)
        {
            var Users = _service.GetUser(id);
            var Customers = _service.GetCustomer(id);
            var listProductid = _service.GetProductIds(id);

            return new UserVm
            {
                UserDto=Users,
                CustomerDto=Customers,
                ListProductId=listProductid

            };
        }
      
        public void DeleteUser(int id)
        {
            _service.DeleteUser(id);
        }


        

    } 
}