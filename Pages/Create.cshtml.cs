using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Console_Manager.Data;
using Console_Manager.Models;

namespace Console_Manager.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Console_Manager.Data.Console_ManagerContext _context;

        public CreateModel(Console_Manager.Data.Console_ManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactManagerModel ContactManagerModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactManagerModel.Add(ContactManagerModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
