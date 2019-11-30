using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ApplicationCore.Services
{
    public class RegisterService
    {
        private readonly IUnitOfWork   _unitOfWork;

        public RegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public void CreateRegister(UserDto userDto,CustomerDto customerDto)
        {
            var Customer = customerDto.ConvertToCustomer();
            _unitOfWork.Registers.Add(Customer);

            _unitOfWork.Complete();

            var User= userDto.ConvertToUser();

            _unitOfWork.Registers.Add(User);

            _unitOfWork.Complete();
        }

       
    }
}