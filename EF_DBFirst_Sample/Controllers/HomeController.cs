using EF_DBFirst_Sample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EF_DBFirst_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfDbfirstSampleContext _context;

        public HomeController(EfDbfirstSampleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sinhViens = _context.SinhViens
                .Where(s => s.NgaySinh.Year >= 2004 && s.NgaySinh.Year <= 2006 && s.Lop.Khoa.TenKhoa == "CNTT")
                .ToList();
            return View(sinhViens);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
