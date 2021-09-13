using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Console_Manager.Data;
using Console_Manager.Models;

namespace Console_Manager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Console_Manager.Data.Console_ManagerContext _context;

        public IndexModel(Console_Manager.Data.Console_ManagerContext context)
        {
            _context = context;
        }

        public IList<ContactManagerModel> ContactManagerModel { get;set; }

        public async Task OnGetAsync()
        {
            ContactManagerModel = await _context.ContactManagerModel.ToListAsync();
        }
    }
}
