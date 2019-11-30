using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class ProductListVm
    {
        public SelectList Genres { get;  set; }
        public SelectList Provider { get; set; }


        public PaginatedList<ProductDto> Products{ get;  set; }
    }
}