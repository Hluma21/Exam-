namespace CityPointHireExam.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime BookingCreatedAt { get; set; }
        public string SpecialRequests { get; set; }

        //Navigation Property
        public Room Room { get; set; }
    }
}

