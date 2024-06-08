using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarFilterQueryResultHandler : IRequestHandler<GetCarFilterQuery, List<GetCarQueryResult>>
    {
        private readonly CarRentContext _context;

        public GetCarFilterQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarFilterQuery request, CancellationToken cancellationToken)
        {
            var values = _context.CarReservations.Include(x => x.Car).ThenInclude(x=>x.Brand).Include(x=>x.Car).ThenInclude(y=>y.Location).Include(x => x.TakeCarLocation).Include(x => x.DropCarLocation).Where(x => x.DropCarDate <= request.TakeCarDate).Where(x=>x.DropCarId== request.TakeCarLocation).ToList();
            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                BrandId = x.Car.Brand.BrandId,
                BrandTitle = x.Car.Brand.BrandTitle,
                Color = x.Car.Color,
                Description = x.Car.Description,
                Door = x.Car.Door,
                Fuel = x.Car.Fuel,
                Km = x.Car.Km,
                LocationId = x.Car.LocationId,
                LocationTitle = x.Car.Location.LocationTitle,
                Luggage = x.Car.Luggage,
                Model = x.Car.Model,
                Passanger = x.Car.Passanger,
                Seat = x.Car.Seat,
                Transmission = x.Car.Transmission,
                Year = x.Car.Year,
                ImageUrl = x.Car.ImageUrl,
                Price = x.Car.Price,
            }).ToList();
        }
    }
}
