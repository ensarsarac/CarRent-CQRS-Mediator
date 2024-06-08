namespace CarRent.DAL.Entity
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
        public List<CarReservation> TakeCarLocations{ get; set; }
        public List<CarReservation> DropCarLocations{ get; set; }
    }
}
