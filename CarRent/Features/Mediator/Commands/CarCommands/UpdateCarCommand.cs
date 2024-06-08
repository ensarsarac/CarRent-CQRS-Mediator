using MediatR;

namespace CarRent.Features.Mediator.Commands.CarCommands
{
    public class UpdateCarCommand:IRequest
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int LocationId { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public decimal Km { get; set; }
        public string Fuel { get; set; }
        public int Seat { get; set; }
        public int Door { get; set; }
        public int Luggage { get; set; }
        public int Passanger { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
