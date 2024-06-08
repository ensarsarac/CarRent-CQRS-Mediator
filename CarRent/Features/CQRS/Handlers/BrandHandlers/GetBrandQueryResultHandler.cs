using CarRent.DAL.Context;
using CarRent.Features.CQRS.Results.BrandResults;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryResultHandler
    {
        private readonly CarRentContext _context;

        public GetBrandQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }
        public List<GetBrandQueryResult> Handle()
        {
            var values = _context.Brands.ToList();
            return values.Select(x => new GetBrandQueryResult
            {
               BrandId=x.BrandId,
               BrandTitle=x.BrandTitle,
            }).ToList();
        }
    }
}
