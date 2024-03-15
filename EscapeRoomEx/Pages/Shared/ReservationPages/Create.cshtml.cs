using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Pages.Shared.ReservationPages
{
    public class CreateModel : PageModel
    {
        private readonly EscapeRoomEx.Data.ApplicationDbContext _context;

        public CreateModel(EscapeRoomEx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerId"] = new SelectList(_context.Set<Player>(), "Id", "FirstName");
        ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reservations Reservations { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservations == null || Reservations == null)
            {
                return Page();
            }

            _context.Reservations.Add(Reservations);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
