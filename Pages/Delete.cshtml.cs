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
    public class DeleteModel : PageModel
    {
        private readonly Console_Manager.Data.Console_ManagerContext _context;

        public DeleteModel(Console_Manager.Data.Console_ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactManagerModel ContactManagerModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactManagerModel = await _context.ContactManagerModel.FirstOrDefaultAsync(m => m.ContactID == id);

            if (ContactManagerModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactManagerModel = await _context.ContactManagerModel.FindAsync(id);

            if (ContactManagerModel != null)
            {
                _context.ContactManagerModel.Remove(ContactManagerModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
