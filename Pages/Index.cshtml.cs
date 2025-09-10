using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bookstore.Data;
using bookstore.Models;
namespace bookstore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DBContext _context;
        public IList<Book> Books { get; set; } = default!;
        public IndexModel(DBContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Books = await _context.Books.Include(b => b.Autor).ToListAsync();
        }
        public void OnPost()
        {
            

        }
    }

}
