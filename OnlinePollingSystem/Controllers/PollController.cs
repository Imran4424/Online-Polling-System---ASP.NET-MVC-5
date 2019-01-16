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
            var polls = _context.Polls.ToList();

            return View(polls);
        }

        // GET: Poll / Timeline 

        public ActionResult Timeline()
        {
            string currentUserId = User.Identity.GetUserId();

            var polls = _context.Polls.Where(p => p.UserIdentity == currentUserId).ToList();

            return View(polls);
        }

        // GET: Poll / Details
        
        public ActionResult Details(int id)
        {
            var detailsModel = new DetailsViewModel
            {
                Poll = _context.Polls.SingleOrDefault(p => p.Id == id),
                Options = _context.Options.Where(p => p.PostId == id).ToList()
            };

            return View(detailsModel);
        }

        // GET: Poll / NewPoll

        public ActionResult NewPoll()
        {
            var newPoll = new NewPollViewModel
            {
                Poll = new Poll(),
                OptionOne = new Option()
            };

            return View(newPoll);
        }


        [HttpPost]
        public ActionResult Save(Poll poll, Option option)
        {
            string currentUserId = User.Identity.GetUserId();

            var currentUserInfo = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            poll.UserIdentity = currentUserId;

            poll.PostedBy = currentUserInfo.Name;

            poll.PostDate = DateTime.Today;

            _context.Polls.Add(poll);

            option.PostId = poll.Id;
            option.VoteCount = 0;
            option.Status = false;

            _context.Options.Add(option);

            _context.SaveChanges();

            return RedirectToAction("Details", "Poll", poll);
        }


        // GET: Post / Delete

        public ActionResult Delete(int id)
        {
            var poll = _context.Polls.SingleOrDefault(p => p.Id == id);

            var options = _context.Options.Where(m => m.PostId == id).ToList();

            _context.Polls.Remove(poll);

            _context.Options.RemoveRange(options);

            _context.SaveChanges();

            return RedirectToAction("Timeline", "Poll");
        }

    }
}