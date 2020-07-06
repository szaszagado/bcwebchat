using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Pages
{
    public class WelcomeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string firstname { get; set; }
        [BindProperty(SupportsGet = true)]
        public string lastname { get; set; }
    }
}