using byudigs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private byu_digsContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, byu_digsContext context)
        {
            _logger = logger;
            _context = context;
        }
        //JAMIE's CONTROLLER PART

        [HttpGet]
        public IActionResult AddBurialSimple()
        {
            
            ViewBag.Plots = _context.Plot;
            return View();
        }

        [HttpPost]
        public IActionResult AddBurialSimple(Plot p,int PlotInfo)
        {
            //int lowpairns = (int)p.LowPairNs;
            //int highpairns = (int)p.HighPairNs;
            //string buriallocationns = p.BurialLocationNs;
            //string burialloactionew = p.BurialLocationEw;
            //int lowpairew = (int)p.LowPairEw;
            //int highpairew = (int)p.HighPairEw;
            return View("BurialList", _context.Plot);
        }

        public IActionResult BurialList()
        {
            return View(_context.Plot);
        }
        //public async Task<IActionResult> BurialList()
        //{
        //    return View(await _context.Plot.ToListAsync());
        //}

        //DONT TOUCH THIS SECTION
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tableau()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
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
