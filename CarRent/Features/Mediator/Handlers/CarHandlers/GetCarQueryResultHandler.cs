using CarRent.DAL.Context;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarQueryResultHandler : IRequestHandler<GetCarQueryResult, List<GetCarQueryResult>>
    {
        private readonly CarRentContext _context;

        public GetCarQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQueryResult request, CancellationToken cancellationToken)
        {
            var values =await _context.Cars.Include(x=>x.Location).Include(x=>x.Brand).ToListAsync();
            return values.Select(x => new GetCarQueryResult()
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandTitle = x.Brand.BrandTitle,
                Color = x.Color,
                Description = x.Description,
                Door = x.Door,
                Fuel = x.Fuel,
                Km = x.Km,
                LocationId = x.LocationId,
                LocationTitle = x.Location.LocationTitle,
                Luggage = x.Luggage,
                Model= x.Model,
                Passanger= x.Passanger,
                Seat = x.Seat,
                Transmission= x.Transmission,
                Year= x.Year,
                ImageUrl= x.ImageUrl,
            }).ToList();
        }
    }
}
