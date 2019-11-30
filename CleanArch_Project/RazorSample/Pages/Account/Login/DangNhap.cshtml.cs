﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;
using Web.ViewModels;

namespace Web.Pages.Login
{

    public class DangNhapModel : PageModel
    {
        private readonly UserService _service;

        public DangNhapModel(UserService service)
        {
            _service = service;
        }


        [BindProperty]
        public User User { get; set; }
        
        public void OnPostLogout()
        {
            HttpContext.Session.Remove("username");

        }


        public IActionResult OnPost()
        {

            var users = _service.GetUsers().ToList<UserDto>();

            foreach (var item in users)
            {
                if (User.UserName == item.UserName && User.UserPassword == item.UserPassword)
                {
                    HttpContext.Session.SetString("username", item.UserName);

                    HttpContext.Session.SetString("userid", item.UserId + "");


                    return RedirectToPage("/Index");
                }

            }


            return Page();
        }
    }
}