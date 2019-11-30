using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages.Register
{
    public class DangKyModel : PageModel
    {
        //private readonly CustomerService _service1;
        private readonly ProductContext _context;

        public DangKyModel(ProductContext context)
        {
            _context = context;
          
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }




            _context.Customer.Add(Customer);

            await _context.SaveChangesAsync();



            User.UserCustomerId = Customer.CustomerId;
            User.UserPermissionId = 3;





            _context.User.Add(User);

            await _context.SaveChangesAsync();


            return Page();
        }
       
    }
}