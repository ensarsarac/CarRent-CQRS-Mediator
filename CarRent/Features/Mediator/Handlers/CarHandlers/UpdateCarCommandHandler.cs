using CarRent.DAL.Context;
using CarRent.Features.Mediator.Commands.CarCommands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly CarRentContext _context;

        public UpdateCarCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Cars.FindAsync(request.CarId);
            value.Description = request.Description;
            value.BrandId = request.BrandId;
            value.Model = request.Model;
            value.Color = request.Color;
            value.LocationId = request.LocationId;
            value.Year = request.Year;
            value.Transmission = request.Transmission;
            value.Km = request.Km;
            value.Fuel = request.Fuel;
            value.Seat = request.Seat;
            value.Door  = request.Door;
            value.Luggage = request.Luggage;
            value.Passanger = request.Passanger;
            value.ImageUrl = request.ImageUrl;
            value.Price = request.Price;
            _context.Cars.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}
