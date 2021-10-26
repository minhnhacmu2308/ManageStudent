using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class SubjectController : Controller
    {
        SubjectRepository subjectRepository = new SubjectRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            var list = subjectRepository.getAll();
            ViewBag.MSG = msg;
            return View(list);
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            subjectRepository.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Add(FormCollection form)
        {
            Subject subject = new Subject();
            subject.name = form["name"];
            subject.status = 1;
            var obj = subjectRepository.getSubjectByName(form["name"]);
            if (obj == null)
            {
                subjectRepository.add(subject);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }

        public ActionResult Update(FormCollection form)
        {
            Subject subject = new Subject();
            subject.name = form["name"];
            subject.id_subject =  Int32.Parse(form["id"]);
            subject.status = 1;
            var obj = subjectRepository.getSubjectByName(form["name"]);
            if (obj == null)
            {
                subjectRepository.update(subject);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objNew = subjectRepository.getSubjectByName(form["name"]);
                if (objNew.name.Equals(form["name"]))
                {
                    subjectRepository.update(subject);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    return RedirectToAction("Index", new { msg = "2" });
                }
                
            }
        }
    }
}