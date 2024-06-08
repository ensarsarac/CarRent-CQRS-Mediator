using CarRent.Features.CQRS.Commands.BrandCommands;
using CarRent.Features.CQRS.Handlers.BrandHandlers;
using CarRent.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly GetBrandQueryResultHandler _brandQueryResultHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly GetBrandByIdQueryResultHandler _getBrandByIdQueryResultHandler;

        public AdminBrandController(GetBrandQueryResultHandler brandQueryResultHandler, CreateBrandCommandHandler createBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, GetBrandByIdQueryResultHandler getBrandByIdQueryResultHandler)
        {
            _brandQueryResultHandler = brandQueryResultHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _getBrandByIdQueryResultHandler = getBrandByIdQueryResultHandler;
        }

        public IActionResult Index()
        {
            var values = _brandQueryResultHandler.Handle();
            return View(values);
        }
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(CreateBrandCommand createBrandCommand)
        {
            _createBrandCommandHandler.Handle(createBrandCommand);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBrand(int id)
        {
            _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return RedirectToAction("Index");
        }
        public IActionResult UpdateBrand(int id)
        {
            var value = _getBrandByIdQueryResultHandler.Handle(new GetBrandByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandCommand updateBrandCommand)
        {
            _updateBrandCommandHandler.Handle(updateBrandCommand);
            return RedirectToAction("Index");
        }
    }
}
