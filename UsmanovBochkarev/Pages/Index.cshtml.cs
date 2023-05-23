using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsmanovBochkarev.Models;

namespace UsmanovBochkarev.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public List<User> User { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            MydbContext db = new MydbContext();
            User = db.Users.ToList();

        }

        public void OnGet()
        {
                
        }
    }
}