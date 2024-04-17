using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebEntityFramework.Models;

namespace WebEntityFramework.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private  MyBlogContext blogContext;
        public IndexModel(ILogger<IndexModel> logger,MyBlogContext myBlogContext)
        {
            _logger = logger;
            blogContext = myBlogContext;
        }

        public void OnGet()
        {
            var post = (from a in blogContext.articles orderby a.PublishDate select a).ToList();
            ViewData["Post"] = post;
        }
    }
}
