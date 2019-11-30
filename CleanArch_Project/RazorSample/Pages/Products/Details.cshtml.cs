using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using ApplicationCore.DTOs;

namespace Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
       
            private readonly ProductService _service;

            public DetailsModel(ProductService service)
            {
                _service = service;
            }

            public ProductDto Product { get; set; }

            public IActionResult OnGet(int id)
            {
                Product = _service.GetProduct(id);

                if (Product == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
}
