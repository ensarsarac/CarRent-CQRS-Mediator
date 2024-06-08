using CarRent.DAL.Entity;
using CarRent.Features.CQRS.Handlers.BrandHandlers;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.Mediator.Commands.CarCommands;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRent.Controllers
{
    public class AdminCarsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetLocationQueryResultHandler _queryHandler;
        private readonly GetBrandQueryResultHandler _brandHandler;
        public AdminCarsController(IMediator mediator, GetLocationQueryResultHandler queryHandler, GetBrandQueryResultHandler brandHandler)
        {
            _mediator = mediator;
            _queryHandler = queryHandler;
            _brandHandler = brandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var value =await _mediator.Send(new GetCarQueryResult());
            return View(value);
        }
        public IActionResult CreateCar()
        {
            var locations = _queryHandler.Handle();
            var brands = _brandHandler.Handle();
            ViewBag.locationsValues = new SelectList(locations.ToList(), "LocationId", "LocationTitle");
            ViewBag.brandsValues = new SelectList(brands.ToList(), "BrandId", "BrandTitle");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand createCarCommand)
        {
            
            await _mediator.Send(createCarCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCar(int id)
        {
            var locations = _queryHandler.Handle();
            var brands = _brandHandler.Handle();
            ViewBag.locationsValues = new SelectList(locations.ToList(), "LocationId", "LocationTitle");
            ViewBag.brandsValues = new SelectList(brands.ToList(), "BrandId", "BrandTitle");
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
        {
            await _mediator.Send(updateCarCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return RedirectToAction("Index");
        }
    }
}
