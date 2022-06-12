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
        MajorRepository majorRepository = new MajorRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            var list = subjectRepository.getAll();
            ViewBag.MSG = msg;
            ViewBag.listMajor = majorRepository.GetAll();
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
            subject.id_major = Int32.Parse(form["id_major"]);
            subject.status = 1;
            var obj = subjectRepository.getSubjectByName(form["name"], Int32.Parse(form["id_major"]));
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
            subject.id_major = Int32.Parse(form["id_major"]);
            subject.status = 1;
            var obj = subjectRepository.getSubjectByName(form["name"], Int32.Parse(form["id_major"]));
            if (obj == null)
            {
                subjectRepository.update(subject);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objNew = subjectRepository.getSubjectByName(form["name"], Int32.Parse(form["id_major"]));
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