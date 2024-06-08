namespace CarRent.Features.CQRS.Commands.LocationCommands
{
    public class UpdateLocationCommand
    {
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
    }
}
