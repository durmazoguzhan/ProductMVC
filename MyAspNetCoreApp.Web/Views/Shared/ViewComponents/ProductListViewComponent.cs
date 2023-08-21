using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type = 1)
        {
            var viewModels = _context.Products.Select(x => new ProductListComponentViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock
            }).ToList();

            if (type == 2)
                return View("Type2", viewModels);
            else
                return View("Default", viewModels);
        }

    }
}
