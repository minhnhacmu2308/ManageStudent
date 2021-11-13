using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleRepository scheduleRepository = new ScheduleRepository();
        SubjectRepository subjectRepository = new SubjectRepository();
        // GET: Schedule
        public ActionResult Index(string msg)
        {
            ViewBag.MSG = msg;
            ViewBag.listSubject = subjectRepository.getAll();
            ViewBag.ListD = scheduleRepository.getDay(); 
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            Schedule schedule = new Schedule();
            schedule.id_subject = Int32.Parse(form["monhoc"]);
            schedule.id_session = Int32.Parse(form["buoi"]);
            schedule.id_day = Int32.Parse(form["thu"]);
            scheduleRepository.add(schedule);
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult Edit(FormCollection form)
        {   
            var monhocnew = Int32.Parse(form["monhocnew"]);
            var monhocold = Int32.Parse(form["monhocold"]);
            var thu = Int32.Parse(form["thu"]);
            var buoi = Int32.Parse(form["buoi"]);
            var result = scheduleRepository.getInfor(thu, buoi, monhocold);
            if (result != null)
            {
                scheduleRepository.delete(thu, buoi, monhocold);
                Schedule schedule = new Schedule();
                schedule.id_subject = monhocnew;
                schedule.id_session = buoi;
                schedule.id_day = thu;
                scheduleRepository.add(schedule);
                return RedirectToAction("Index", new { msg = "1" });
            }
            return RedirectToAction("Index", new { msg = "2" });
            
        }
        public ActionResult Delete(FormCollection form)
        {
            var monhoc = Int32.Parse(form["monhoc"]);
            var buoi = Int32.Parse(form["buoi"]);
            var thu = Int32.Parse(form["thu"]);
            var result = scheduleRepository.getInfor(thu, buoi, monhoc);
            if(result != null)
            {
                scheduleRepository.delete(thu, buoi, monhoc);
                return RedirectToAction("Index", new { msg = "1" });
            }
            return RedirectToAction("Index", new { msg = "2" });
        }
    }
}