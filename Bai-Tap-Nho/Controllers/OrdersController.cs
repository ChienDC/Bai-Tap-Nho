using Bai_Tap_Nho.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bai_Tap_Nho.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}