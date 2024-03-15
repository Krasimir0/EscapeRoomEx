namespace EscapeRoomEx.Data
{
    public class Player
    {
        public Player()
        {
            Reservations = new List<Reservations>();
            PlayerCount++;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public List<Reservations> Reservations { get; set; }
        public static int PlayerCount { get; private set; }
    }
}
