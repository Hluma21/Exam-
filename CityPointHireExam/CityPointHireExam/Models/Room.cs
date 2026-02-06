namespace CityPointHireExam.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public float HourlyRate { get; set; }
        public bool IsAvailable { get; set; }


        //Navigation Property
        public ICollection<Booking>? Bookings { get; set; }
    }
}

