using CarRent.DAL.Context;
using CarRent.Features.CQRS.Results.LocationResults;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryResultHandler
    {
        private readonly CarRentContext _context;

        public GetLocationQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }
        public List<GetLocationQueryResult> Handle()
        {
            var values = _context.Locations.ToList();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                LocationTitle=x.LocationTitle,
            }).ToList();
        }
    }
}
