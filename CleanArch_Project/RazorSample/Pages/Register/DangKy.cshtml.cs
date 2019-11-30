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
        private readonly ProductService _service2;

       // public DangKyModel(CustomerService service1, ProductService service2)
        //{
         //   _service1 = service1;
        //    _service2 = service2;
        //}

        public IActionResult OnGet()
        {
            return Page();
        }

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

            //_service1.CreateCustomer(Customer);
            _service2.CreateProduct(Product);


            return RedirectToPage("/Customers/Index");
        }
       
    }
}