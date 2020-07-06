using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using probagetrequest.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace probagetrequest.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }
        private DatabaseContext db;
        public ProfileModel(DatabaseContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            var username = HttpContext.Session.GetString("username");
            account = db.Accounts.FirstOrDefault(a => a.Username.Equals(username));
        }
        public IActionResult OnPost()
        {
            if(!string.IsNullOrEmpty(account.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            else
            {
                account.Password = db.Accounts.AsNoTracking().SingleOrDefault(a => a.Id == account.Id).Password;
            }
            db.SaveChanges();
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToPage("Wilcome");
        }

    }
}