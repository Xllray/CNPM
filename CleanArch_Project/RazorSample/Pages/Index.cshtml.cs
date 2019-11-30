using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {

        public string Message { get; private set; }


        [BindProperty(SupportsGet = true)]
        public string CurrentFilterProduct { get; set; }

        public void OnGet()
        {
            Message="Lop DCT117* sang thu 7";
        }
    }
}