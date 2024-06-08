namespace CarRent.DAL.Entity
{
    public class CarReservation
    {
        public int CarReservationId { get; set; }
        public int TakeCarId { get; set; }
        public Location TakeCarLocation { get; set; }
        public int DropCarId { get; set; }
        public Location DropCarLocation { get; set; }
        public DateTime TakeCarDate { get; set; }
        public DateTime DropCarDate { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
