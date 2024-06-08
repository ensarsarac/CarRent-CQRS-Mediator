using CarRent.DAL.Context;
using CarRent.Features.Mediator.Commands.CarCommands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand>
    {
        private readonly CarRentContext _context;

        public RemoveCarCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Cars.FindAsync(request.Id);
            _context.Cars.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
