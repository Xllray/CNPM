using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages.Account.Info
{
    public class IndexModel : PageModel
    {
        private readonly UserVmService _service;

        public IndexModel(UserVmService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {

        }
    }
}