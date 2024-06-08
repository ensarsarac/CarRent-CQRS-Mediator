using CarRent.Features.CQRS.Commands.LocationCommands;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.CQRS.Queries.LocationQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly GetLocationByIdQueryResultHandler _getLocationByIdQueryResultHandler;
        private readonly GetLocationQueryResultHandler _getLocationQueryResultHandler;
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;

        public AdminLocationController(RemoveLocationCommandHandler removeLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler, CreateLocationCommandHandler createLocationCommandHandler, GetLocationQueryResultHandler getLocationQueryResultHandler, GetLocationByIdQueryResultHandler getLocationByIdQueryResultHandler)
        {
            _removeLocationCommandHandler = removeLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _createLocationCommandHandler = createLocationCommandHandler;
            _getLocationQueryResultHandler = getLocationQueryResultHandler;
            _getLocationByIdQueryResultHandler = getLocationByIdQueryResultHandler;
        }

        public IActionResult Index()
        {
            var values = _getLocationQueryResultHandler.Handle();
            return View(values);
        }
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLocation(CreateLocationCommand createLocationCommand)
        {
            _createLocationCommandHandler.Handle(createLocationCommand);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteLocation(int id)
        {
            _removeLocationCommandHandler.Handle(new RemoveLocationCommand(id));
            return RedirectToAction("Index");
        }
        public IActionResult UpdateLocation(int id)
        {
            var value = _getLocationByIdQueryResultHandler.Handle(new GetLocationByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateLocation(UpdateLocationCommand updateLocationCommand)
        {
            _updateLocationCommandHandler.Handle(updateLocationCommand);
            return RedirectToAction("Index");
        }
    }
}
