using System.ComponentModel.DataAnnotations.Schema;

namespace EscapeRoomEx.Data
{
    public class Reservations
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int PlayerId { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player? Player { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }
    }
}