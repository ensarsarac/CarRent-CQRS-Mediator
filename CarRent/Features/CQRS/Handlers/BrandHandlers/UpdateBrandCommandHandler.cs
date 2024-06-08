using CarRent.DAL.Context;
using CarRent.DAL.Entity;
using CarRent.Features.CQRS.Commands.BrandCommands;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly CarRentContext _context;

        public UpdateBrandCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateBrandCommand updateBrandCommand)
        {
            var value = _context.Brands.Find(updateBrandCommand.BrandId);
            value.BrandTitle = updateBrandCommand.BrandTitle;
            _context.Brands.Update(value);
            _context.SaveChanges();
        }
    }
}
