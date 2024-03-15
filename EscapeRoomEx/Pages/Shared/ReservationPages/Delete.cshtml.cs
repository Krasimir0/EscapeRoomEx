using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Pages.Shared.ReservationPages
{
    public class DeleteModel : PageModel
    {
        private readonly EscapeRoomEx.Data.ApplicationDbContext _context;

        public DeleteModel(EscapeRoomEx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reservations Reservations { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);

            if (reservations == null)
            {
                return NotFound();
            }
            else 
            {
                Reservations = reservations;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }
            var reservations = await _context.Reservations.FindAsync(id);

            if (reservations != null)
            {
                Reservations = reservations;
                _context.Reservations.Remove(Reservations);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
