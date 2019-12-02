using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;
using Web.ViewModels;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        //se su dung ProductListVmService de lay danh sach san pham moi nhat
        
         private readonly ProductListVmService _ProductService;
        public IndexModel(ProductListVmService ProductService)
        {
            _ProductService = ProductService;
        }

        public string Message { get; private set; }


        [BindProperty(SupportsGet = true)]
        public string CurrentFilterProduct { get; set; }

        public ProductListVm productListVm { get; set; }

        public void OnGet()
        {
            productListVm  =_ProductService.GetListSPMoiNhat(3); //so 3 la so san pham moi muon lay
        }


    }
}