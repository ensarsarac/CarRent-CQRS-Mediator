using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using CarRent.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRent.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetLocationQueryResultHandler _queryHandler;

        public DefaultController(IMediator mediator, GetLocationQueryResultHandler queryHandler)
        {
            _mediator = mediator;
            _queryHandler = queryHandler;
        }

        public IActionResult Index()
        {
            ViewBag.takelocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
            ViewBag.droplocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
            return View();
        }
        [HttpPost]
        public IActionResult Index(GetFilterCarDto getFilterCarDto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("RentCar", getFilterCarDto);
            }
            else
            {
                ViewBag.takelocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
                ViewBag.droplocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
                ModelState.AddModelError("", "Alanlar boş bırakılamaz.");
                return View(getFilterCarDto);
            }
        }
        public async Task<IActionResult> RentCar(GetFilterCarDto? value)
        {
            if(value.TakeCarLocation > 0)
            {
                var res = new GetCarFilterQuery(value.TakeCarLocation, value.DropCarLocation, value.TakeCarDate, value.DropCarDate);
                var values = await _mediator.Send(res);
                if (values.Count() <= 0)
                {
                    ViewBag.warning = "Aradığınız kriterlerde herhangi bir araç bulunamamıştır";
                    return View(values);
                }
                else
                return View(values);
            }
            else
            {
                var values = await _mediator.Send(new GetCarQueryResult());
                return View(values);
            }
        }
    }
}
