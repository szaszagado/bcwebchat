using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using probagetrequest.Models;
using Microsoft.AspNetCore.Http;

namespace probagetrequest.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }

        public string Msg;

        public DatabaseContext db;
        public IndexModel(DatabaseContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {
            account = new Account();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            var acc = login(account.Username, account.Password);
            if (acc == null)
            {
                Msg = "Invalid username or password!";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", acc.Username);
                return RedirectToPage("Wilcome");
            }
        }

        private Account login(string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(a => a.Username.Equals(username));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
