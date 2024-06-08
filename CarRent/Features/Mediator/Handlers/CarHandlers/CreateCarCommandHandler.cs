using CarRent.DAL.Context;
using CarRent.DAL.Entity;
using CarRent.Features.Mediator.Commands.CarCommands;
using MediatR;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly CarRentContext _context;

        public CreateCarCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _context.Cars.AddAsync(new Car
            {
                BrandId = request.BrandId,
                Model = request.Model,
                Color = request.Color,
                LocationId = request.LocationId,
                Year = request.Year,
                Transmission = request.Transmission,
                Km = request.Km,
                Fuel = request.Fuel,
                Seat = request.Seat,
                Door = request.Door,
                Luggage = request.Luggage,
                Passanger = request.Passanger,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
            });
            await _context.SaveChangesAsync();
        }
    }
}
