using System;
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
        
       
        
        public IActionResult OnPost()
        {
            var item = _service.Login(User.UserName, User.UserPassword);

            if ( item != null)
            {

                
                HttpContext.Session.SetString("username", item.UserName);

                HttpContext.Session.SetString("userid", item.UserId + "");


                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
                   
                

        }
        
    }
}