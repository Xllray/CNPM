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
    public class UserService
    {
        private readonly IUnitOfWork   _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserDto GetUser(int id)
        {
            var User = _unitOfWork.Users.GetBy(id);
            return User.ConvertToUserDto();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var Users = _unitOfWork.Users.GetAll().ToList();
            return Users.ConvertToUserDtos();
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