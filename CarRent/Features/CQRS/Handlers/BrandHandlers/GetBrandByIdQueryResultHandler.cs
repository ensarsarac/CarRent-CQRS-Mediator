using CarRent.DAL.Context;
using CarRent.Features.CQRS.Queries.BrandQueries;
using CarRent.Features.CQRS.Results.BrandResults;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryResultHandler
    {
        private readonly CarRentContext _context;

        public GetBrandByIdQueryResultHandler(CarRentContext context)
        {
            _context = context;
        }
        public GetBrandByIdQueryResult Handle(GetBrandByIdQuery getBrandByIdQuery)
        {
            var value = _context.Brands.Find(getBrandByIdQuery.Id);
            return new GetBrandByIdQueryResult
            {
                BrandTitle = value.BrandTitle,
                BrandId=value.BrandId,
            };
        }
    }
}
