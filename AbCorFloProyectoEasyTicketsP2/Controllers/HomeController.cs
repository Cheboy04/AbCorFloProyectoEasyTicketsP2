using AbCorFloProyectoEasyTicketsP2.Models;
using AbCorFloProyectoEasyTicketsP2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbCorFloProyectoEasyTicketsP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AbCorFloProyectoEasyTicketsP2Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AbCorFloProyectoEasyTicketsP2Context context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            return View(await _context.Ticket.ToListAsync());
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
