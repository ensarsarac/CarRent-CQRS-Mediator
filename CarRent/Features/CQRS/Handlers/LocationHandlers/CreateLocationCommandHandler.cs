using CarRent.DAL.Context;
using CarRent.DAL.Entity;
using CarRent.Features.CQRS.Commands.LocationCommands;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler
    {
        private readonly CarRentContext _context;

        public CreateLocationCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(CreateLocationCommand createLocationCommand)
        {
            _context.Locations.Add(new Location { LocationTitle = createLocationCommand.LocationTitle });
            _context.SaveChanges();
        }
    }
}
