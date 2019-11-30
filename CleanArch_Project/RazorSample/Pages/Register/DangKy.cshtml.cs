using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Register
{
    public class DangKyModel : PageModel
    {
        //private readonly CustomerService _service1;
        private readonly RegisterService _service;

        public DangKyModel(RegisterService service)
        {
            _service = service;
          
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public UserDto User { get; set; }
        [BindProperty]
        public CustomerDto Customer { get; set; }
        [BindProperty]
        public ProductDto Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
           

           Customer.CustomerId = 2;
            Customer.Name = "huy";

            Customer.Phone = "321312";
            Customer.Email = "321312";
            Customer.Address = "321312";

            User.UserCustomerId = Customer.CustomerId;
            User.UserPermissionId = 1;
            User.UserName = "huy";
            User.UserPassword = "1232";
            User.UserCustomerId = 1;

            _service.CreateRegister(User, Customer);


            return Page();
        }
       
    }
}