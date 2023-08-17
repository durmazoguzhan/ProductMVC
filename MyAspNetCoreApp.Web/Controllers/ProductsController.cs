using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["status"] = "Ürün başarıyla silindi.";
            }
            else
                TempData["status"] = "Ürün bulunamadı.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>{
                new(){ Data="Beyaz", Value="Beyaz" },
                new(){ Data="Siyah", Value="Siyah" },
                new(){ Data="Mavi", Value="Mavi" },
                new(){ Data="Kırmızı", Value="Kırmızı" },
                new(){ Data="Yeşil", Value="Yeşil" },
                new(){ Data="Sarı", Value="Sarı" },
                new(){ Data="Mor", Value="Mor" },
                new(){ Data="Kahverengi", Value="Kahverengi" },
                new(){ Data="Turuncu", Value="Turuncu" },
            }, "Value", "Data");

            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay", 1 },
                { "3 Ay", 3 },
                { "6 Ay", 6 },
                { "12 Ay", 12 }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            if (!String.IsNullOrEmpty(newProduct.Name) && (newProduct.Name.StartsWith("Ğ") || newProduct.Name.StartsWith("ğ")))
            {
                ModelState.AddModelError(String.Empty, "Ürün adı Ğ harfi ile başlayamaz.");
            }

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>{
                new(){ Data="Beyaz", Value="Beyaz" },
                new(){ Data="Siyah", Value="Siyah" },
                new(){ Data="Mavi", Value="Mavi" },
                new(){ Data="Kırmızı", Value="Kırmızı" },
                new(){ Data="Yeşil", Value="Yeşil" },
                new(){ Data="Sarı", Value="Sarı" },
                new(){ Data="Mor", Value="Mor" },
                new(){ Data="Kahverengi", Value="Kahverengi" },
                new(){ Data="Turuncu", Value="Turuncu" },
            }, "Value", "Data");

            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay", 1 },
                { "3 Ay", 3 },
                { "6 Ay", 6 },
                { "12 Ay", 12 }
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();
                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");
                }
                catch (Exception error)
                {
                    ModelState.AddModelError(String.Empty, $"Ürün kaydedilirken bir hata meydana geldi. Hata Mesajı: {error.Message}");
                    return View();
                }

            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>{
                new(){ Data="Beyaz", Value="Beyaz" },
                new(){ Data="Siyah", Value="Siyah" },
                new(){ Data="Mavi", Value="Mavi" },
                new(){ Data="Kırmızı", Value="Kırmızı" },
                new(){ Data="Yeşil", Value="Yeşil" },
                new(){ Data="Sarı", Value="Sarı" },
                new(){ Data="Mor", Value="Mor" },
                new(){ Data="Kahverengi", Value="Kahverengi" },
                new(){ Data="Turuncu", Value="Turuncu" },
            }, "Value", "Data", product.Color);

            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay", 1 },
                { "3 Ay", 3 },
                { "6 Ay", 6 },
                { "12 Ay", 12 }
            };

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }
    }
}
