using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Pages.Shared.ReservationPages
{
    public class EditModel : PageModel
    {
        private readonly EscapeRoomEx.Data.ApplicationDbContext _context;

        public EditModel(EscapeRoomEx.Data.ApplicationDbContext context)
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

            var reservations =  await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);
            if (reservations == null)
            {
                return NotFound();
            }
            Reservations = reservations;
           ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "Id");
           ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
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

            _context.Attach(Reservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationsExists(Reservations.Id))
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

        private bool ReservationsExists(int id)
        {
          return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
