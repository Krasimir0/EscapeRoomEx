using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Pages.Shared.RoomPages
{
    public class IndexModel : PageModel
    {
        private readonly EscapeRoomEx.Data.ApplicationDbContext _context;

        public IndexModel(EscapeRoomEx.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Room != null)
            {
                Room = await _context.Room.ToListAsync();
            }
        }
    }
}
