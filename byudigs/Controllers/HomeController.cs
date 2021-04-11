using byudigs.Models;
using Microsoft.AspNetCore.Authorization;
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
        //J.R.'s CONTROLLER PART



        //JAMIE's CONTROLLER PART
        [Authorize(Roles ="SuperAdmin, Admin")]
        [HttpGet]
        public IActionResult AddBurialSimple()
        {
            ViewBag.SelectedPlot = 0;
            ViewBag.Plots = _context.Plot;
            ViewBag.Sublocation = _context.Sublocation;
            return View();
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        public IActionResult AddBurialSimple(Burial b,int PlotInfo, int month, int day, int year, int SublocationInfo)
        {
            //This will grab the largest date id and increment it one to make sure that it is unique
            int dateid = _context.Date.Select(x => x.DateId).Max();
            dateid = dateid + 1;

            //This will add in the date into the date database
            _context.Date.Add(new Date
            {
                DateId = dateid,
                Month = month,
                Day = day,
                Year = year
            }); ;
            _context.SaveChanges();

            //This will grab the largest burial id
            int burialid = _context.Burial.Select(x => x.BurialId).Max();
            burialid = burialid + 1;
            _context.Burial.Add(new Burial
            {
                BurialId = burialid,
                RackNum = b.RackNum,
                BagNum = b.BagNum,
                BurialNum = b.BurialNum,
                BurialSubnum = b.BurialSubnum,
                PreviouslySampled = b.PreviouslySampled,
                Notes = b.Notes,
                //make this so that the plot info is passed in based on if a new one is created or not
                PlotId = PlotInfo,
                //add in sublocation id here
                SublocationId = SublocationInfo,
                DateId = dateid
            });

            _context.SaveChanges();
            //int highpairew = (int)p.HighPairEw;
            return View("BurialList", _context.Plot);
        }

        [HttpGet]
        public IActionResult AddNewPlot()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewPlot(Plot p)
        {
            int plotid = _context.Plot.Select(x => x.PlotId).Max();
            plotid = plotid + 1;
            p.PlotId = plotid;
            _context.Plot.Add(p);
            _context.SaveChanges();
            ViewBag.SelectedPlot = p.PlotId;
            ViewBag.Plots = _context.Plot;
            ViewBag.Sublocation = _context.Sublocation;
            return View("AddBurialSimple");
        }


        public IActionResult BurialList()
        {
            return View(_context.Plot);
        }


        //DONT TOUCH THIS SECTION
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Tableau()
        {
            return View();
        }
        [AllowAnonymous]

        public IActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
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
