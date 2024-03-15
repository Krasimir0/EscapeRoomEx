using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EscapeRoomEx.Data;

namespace EscapeRoomEx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EscapeRoomEx.Data.Room>? Room { get; set; }
        public DbSet<EscapeRoomEx.Data.Reservations>? Reservations { get; set; }
        public DbSet<EscapeRoomEx.Data.Player>? Player { get; set; }
       
    }
}
