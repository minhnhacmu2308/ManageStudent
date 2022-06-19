using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class FeedbackController : Controller
    {
        FeedbackRepository feedbackRepository = new FeedbackRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = feedbackRepository.getAll();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Feedback feedback)
        {
            var user = (User)Session["USER"];
            feedback.id_user = user.id_user;
            feedback.created = DateTime.Now;
            feedbackRepository.add(feedback);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}