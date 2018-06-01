using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostInWoodsDemo.Factory;
using LostInWoodsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LostInWoodsDemo.Controllers
{
    public class HomeController : Controller
    {
    private readonly TrailFactory _trailFactory;
 
        public HomeController(TrailFactory connect)
        {
            _trailFactory = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = _trailFactory.GetAllTrails();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("createTrail")]
        public IActionResult createTrail(Trail t)
        {
            if (ModelState.IsValid)
            {
                _trailFactory.AddTrail(t);   
                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpGet]
        [Route("trails/{TrailId}")]
        public IActionResult Trails(int TrailId)
        {
            ViewBag.trail = _trailFactory.GetAllTrails().Single(a => a.TrailId == TrailId);
            return View();
        }
    }
}
