using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Console_Manager.Data;
using Console_Manager.Models;

namespace Console_Manager.Pages
{
    public class EditModel : PageModel
    {
        private readonly Console_Manager.Data.Console_ManagerContext _context;

        public EditModel(Console_Manager.Data.Console_ManagerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactManagerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactManagerModelExists(ContactManagerModel.ContactID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactManagerModelExists(int id)
        {
            return _context.ContactManagerModel.Any(e => e.ContactID == id);
        }
    }
}
