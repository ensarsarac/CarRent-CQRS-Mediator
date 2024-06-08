using CarRent.DAL.Context;
using CarRent.Features.CQRS.Commands.LocationCommands;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly CarRentContext _context;

        public UpdateLocationCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateLocationCommand updateLocationCommand)
        {
            var value = _context.Locations.Find(updateLocationCommand.LocationId);
            value.LocationTitle = updateLocationCommand.LocationTitle;
            _context.Locations.Update(value);
            _context.SaveChanges();
        }
    }
}
