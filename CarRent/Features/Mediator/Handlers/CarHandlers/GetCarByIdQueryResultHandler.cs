using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarByIdQueryResultHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly CarRentContext _context;

        public GetCarByIdQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Cars.Include(x=>x.Location).Include(x=>x.Brand).Where(x => x.CarId == request.Id).FirstOrDefaultAsync();
            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                BrandId = value.BrandId,
                BrandTitle = value.Brand.BrandTitle,
                Color = value.Color,
                Description = value.Description,
                Door = value.Door,
                Fuel = value.Fuel,
                Km = value.Km,
                LocationId = value.LocationId,
                LocationTitle = value.Location.LocationTitle,
                Luggage = value.Luggage,
                Model = value.Model,
                Passanger = value.Passanger,
                Seat = value.Seat,
                Transmission = value.Transmission,
                Year = value.Year,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
