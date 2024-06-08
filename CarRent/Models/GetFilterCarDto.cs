namespace CarRent.Models
{
    public class GetFilterCarDto
    {
        public int TakeCarLocation { get; set; }
        public int DropCarLocation { get; set; }
        public DateTime TakeCarDate { get; set; }
        public DateTime DropCarDate { get; set; }
    }
}
