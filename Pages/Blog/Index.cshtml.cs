using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebEntityFramework.Models;

namespace WebEntityFramework.Page_Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebEntityFramework.Models.MyBlogContext _context;

        public IndexModel(WebEntityFramework.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.articles.ToListAsync();
        }
    }
}
