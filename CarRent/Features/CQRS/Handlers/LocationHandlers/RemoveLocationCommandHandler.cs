using CarRent.DAL.Context;
using CarRent.Features.CQRS.Commands.LocationCommands;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler
    {
        private readonly CarRentContext _context;

        public RemoveLocationCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(RemoveLocationCommand removeLocationCommand)
        {
            var value = _context.Locations.Find(removeLocationCommand.Id);
            _context.Locations.Remove(value);
            _context.SaveChanges();
        }
    }
}
