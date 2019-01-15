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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Poll / Index 

        public ActionResult Index()
        {
            var polls = _context.Polls

            return View();
        }
    }
}