using CarRent.DAL.Context;
using CarRent.DAL.Entity;
using CarRent.Features.CQRS.Commands.BrandCommands;
using CarRent.Features.CQRS.Queries.BrandQueries;
using CarRent.Features.CQRS.Results.BrandResults;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly CarRentContext _context;

        public CreateBrandCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(CreateBrandCommand createBrandCommand)
        {
            _context.Brands.Add(new Brand
            {
                BrandTitle = createBrandCommand.BrandTitle
            });
            _context.SaveChanges();
        }
    }
}
