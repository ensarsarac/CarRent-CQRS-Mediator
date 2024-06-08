using CarRent.DAL.Context;
using CarRent.Features.CQRS.Queries.LocationQueries;
using CarRent.Features.CQRS.Results.LocationResults;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryResultHandler
    {
        private readonly CarRentContext _context;

        public GetLocationByIdQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }
        public GetLocationByIdQueryResult Handle(GetLocationByIdQuery getLocationByIdQuery)
        {
            var values = _context.Locations.Find(getLocationByIdQuery.Id);
            return new GetLocationByIdQueryResult
            {
                LocationTitle=values.LocationTitle,
                LocationId=values.LocationId,
            };
        }
    }
}
