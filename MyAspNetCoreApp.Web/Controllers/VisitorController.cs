using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class VisitorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public VisitorController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                visitor.Created = DateTime.Now;
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                TempData["result"] = "Yorum başarıyla kaydedildi!";
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum kaydedilirken bir hata oluştu!";
            }

            return RedirectToAction("Index");
        }
    }
}
