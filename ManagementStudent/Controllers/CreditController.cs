using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class CreditController : Controller
    {
        CreditRepository creditRepository = new CreditRepository();
        SubjectRepository subjectRepository = new SubjectRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = creditRepository.getAll();
            ViewBag.MSG = msg;
            return View();
        }

        public ActionResult Accept(int id)
        {
            creditRepository.update(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult List(string msg)
        {
            var user = (User)Session["USER"];
            ViewBag.List = subjectRepository.getCredit(user.id_major);
            ViewBag.MSG = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            var user = (User)Session["USER"];
            Credit credit = new Credit
            {
                id_subject = id,
                id_user = user.id_user,
                status = 0,
                created = DateTime.Now
            };
            var check = creditRepository.check(credit.id_user, credit.id_subject);
            if(check.Count > 0)
            {
                return RedirectToAction("List", new { msg = "2" });
            }
            else
            {
                creditRepository.add(credit);
                return RedirectToAction("List", new { msg = "1" });
            }
        }

        public ActionResult Regist()
        {
            var user = (User)Session["USER"];
            ViewBag.List = creditRepository.getUser(user.id_user);
            return View();
        }

    }
}