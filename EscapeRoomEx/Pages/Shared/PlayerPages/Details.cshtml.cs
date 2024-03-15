using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Pages.Shared.PlayerPages
{
    public class DetailsModel : PageModel
    {
        private readonly EscapeRoomEx.Data.ApplicationDbContext _context;

        public DetailsModel(EscapeRoomEx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Player Player { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = player;
            }
            return Page();
        }
    }
}
