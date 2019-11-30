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
    public class RegisterVmService 
    {
       
        
        private readonly RegisterService _service;

        public RegisterVmService(RegisterService RegisterService)
        {
            _service = RegisterService;
        }
        
       
        public void CreateRegisters(UserDto user,CustomerDto customer)
        {
            _service.CreateRegister(user, customer);
        }


       

    } 
}