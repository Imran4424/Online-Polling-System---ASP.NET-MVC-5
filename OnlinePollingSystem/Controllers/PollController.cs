using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using OnlinePollingSystem.Models;

namespace OnlinePollingSystem.Controllers
{
    public class PollController : Controller
    {
        private ApplicationDbContext _context;

        public PollController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Poll
        public ActionResult Index()
        {
            return View();
        }
    }
}