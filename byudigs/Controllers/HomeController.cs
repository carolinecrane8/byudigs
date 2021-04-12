﻿using byudigs.Models;
using byudigs.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
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
        //[Authorize(Roles ="SuperAdmin, Admin")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddBurialSimple()
        {
            ViewBag.SelectedPlot = 0;
            ViewBag.Plots = _context.Plot;
            ViewBag.Sublocation = _context.Sublocation;
            return View();
        }
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddBurialSimple(Burial b,int PlotInfo, int month, int day, int year, int SublocationInfo,int SouthToHead, int SouthToFeet, int WestToHead, int WestToFeet, int Length, int Depth)
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
            //add the data to burial advanced
            int advancedid = _context.BurialAdvanced.Select(x => x.AdvancedId).Max();
            advancedid = advancedid + 1;
            _context.BurialAdvanced.Add(new BurialAdvanced
            {
                AdvancedId = advancedid,
                BurialId = burialid,
                SouthToFeet = SouthToFeet,
                SouthToHead = SouthToFeet,
                EastToFeet = WestToFeet,
                EastToHead = WestToHead,
                BurialDepth = Depth,
                LengthOfRemains = Length
            });

            int cranialid = _context.Cranial.Select(x => x.CranialId).Max();
            var updatecranial = _context.Cranial.Where(x => x.CranialId == cranialid).FirstOrDefault();
            updatecranial.BurialId = burialid;

            _context.SaveChanges();
            //int highpairew = (int)p.HighPairEw;
            return View("BurialList", _context.Plot);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddNewPlot()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddBurialAdvanced()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddBurialAdvanced(BurialAdvanced ba)
        {
            int plotid = _context.Plot.Select(x => x.PlotId).Max();

            return View("AddBurialSimple");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddCranial()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddCranial(Cranial c)
        {
            int cranialid = _context.Cranial.Select(x => x.CranialId).Max();
            cranialid = cranialid + 1;
            ViewBag.SelectedPlot = 0;
            ViewBag.Plots = _context.Plot;
            ViewBag.Sublocation = _context.Sublocation;
            _context.Cranial.Add(new Cranial
            {
                CranialId = cranialid,
                BurialId = null,
                TubeNum = c.TubeNum,
                Description = c.Description,
                SizeMl = c.SizeMl,
                Foci = c.Foci,
                C14Sample2017 = c.C14Sample2017,
                Location = c.Location,
                Question = c.Question,
                Conventional14cAgeBp = c.Conventional14cAgeBp,
                _14cCalendarDate = c._14cCalendarDate,
                Calibrated95CalendarDateMax = c.Calibrated95CalendarDateMax,
                Calibrated95CalendarDateMin = c.Calibrated95CalendarDateMin,
                Calibrated95CalendarDateAvg = c.Calibrated95CalendarDateAvg,
                Calibrated95CalendarDateSpan = c.Calibrated95CalendarDateSpan,
                Category = c.Category,
                LabNotes = c.LabNotes
            });
            _context.SaveChanges();
            return View("AddBurialSimple");
        }

        [AllowAnonymous]
        public IActionResult BurialList(string searchString)
        {
            ViewBag.Burial = _context.Burial;
            ViewBag.BurialAdvanced = _context.BurialAdvanced;
            ViewBag.Sublocation = _context.Sublocation;
            ViewBag.Date = _context.Date;
            //var burials = _context.BurialAdvanced.FromSqlRaw("SELECT * from burial_advanced ba join burial b on ba.burial_id = b.burial_id join plot p on b.plot_id = p.plot_id join sublocation s on b.sublocation_id = s.sublocation_id");
           
            //Filter by hair color
            if (!String.IsNullOrEmpty(searchString))
            {
                List<Burial> burial = _context.Burial.ToList();
                List<Plot> plot = _context.Plot.ToList();
                List<Sublocation> sublocation = _context.Sublocation.ToList();
                List<BurialAdvanced> burialadvanced = _context.BurialAdvanced.Where(x => x.HairColor.Contains(searchString)).ToList();
               var burialRecord = from ba in burialadvanced
                               join b in burial on ba.BurialId equals b.BurialId into table1
                               from b in table1.ToList()
                               join p in plot on b.PlotId equals p.PlotId into table2
                               from p in table2.ToList()
                               join s in sublocation on b.SublocationId equals s.SublocationId into table3
                               from s in table3.ToList()
                               select new ViewModel
                               {
                                   burial = b,
                                   burialadvanced = ba,
                                   plot = p,
                                   sublocation = s
                               };
                return View(burialRecord);
            }
            else
            {
                List<Burial> burial = _context.Burial.ToList();
                List<Plot> plot = _context.Plot.ToList();
                List<Sublocation> sublocation = _context.Sublocation.ToList();
                List<BurialAdvanced> burialadvanced = _context.BurialAdvanced.ToList();

                var burialRecord = from ba in burialadvanced
                                   join b in burial on ba.BurialId equals b.BurialId into table1
                                   from b in table1.ToList()
                                   join p in plot on b.PlotId equals p.PlotId into table2
                                   from p in table2.ToList()
                                   join s in sublocation on b.SublocationId equals s.SublocationId into table3
                                   from s in table3.ToList()
                                   select new ViewModel
                                   {
                                       burial = b,
                                       burialadvanced = ba,
                                       plot = p,
                                       sublocation = s
                                   };
                return View(burialRecord);
            }
            
            //return View(burialRecord.ToList());
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
