using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;
using Web.ViewModels;

namespace Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductListVmService _ProductService;
        public IndexModel(ProductListVmService ProductService)
        {
            _ProductService = ProductService;
        }

        [BindProperty(SupportsGet = true)]
        public string CurrentFilterProduct { get; set; }

      

        [BindProperty(SupportsGet = true)]
        public string typename { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sort{ get; set; }

        public ProductListVm ProductIndexVM { get; set; }
        public void OnGet(int pageIndex=1)
        {
            if(sort == "giam")
            {
              
                ProductIndexVM = _ProductService.GetProductPriceDecrease(CurrentFilterProduct, typename, pageIndex);

            }
            else
            {
                ProductIndexVM = _ProductService.GetProductIndexViewModel(CurrentFilterProduct, typename, pageIndex);
            }

          


        }
        



    }
}