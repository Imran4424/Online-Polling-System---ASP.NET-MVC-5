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
        public ActionResult Save(NewPollViewModel newPoll)
        {
            string currentUserId = User.Identity.GetUserId();

            var currentUserInfo = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            newPoll.Poll.UserIdentity = currentUserId;

            newPoll.Poll.PostedBy = currentUserInfo.Name;

            newPoll.Poll.PostDate = DateTime.Today;

            _context.Polls.Add(newPoll.Poll);

            _context.SaveChanges();

            

            newPoll.OptionOne.PostId = _context.Polls.Max(lastPoll => lastPoll.Id);
            newPoll.OptionOne.VoteCount = 1;
            newPoll.OptionOne.Status = true;
            newPoll.OptionOne.CheckedBy.Add(currentUserInfo.Name);

            _context.Options.Add(newPoll.OptionOne);

            _context.SaveChanges();

            return RedirectToAction("Details", "Poll", newPoll.Poll);
        }



        // GET: Post / NewOption

        [HttpPost]
        public ActionResult NewOption(Option option, Poll poll)
        {
            string currentUserId = User.Identity.GetUserId();

            var currentUserInfo = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            option.PostId = poll.Id;
            option.VoteCount = 1;
            option.CheckedBy.Add(currentUserInfo.Name);
            option.Status = true;

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