using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class ScoreController : Controller
    {
        ScoreRepository scoreRepository = new ScoreRepository();
        UserRepository userRepository = new UserRepository();
        SubjectRepository subjectRepository = new SubjectRepository();  
        // GET: Score
        public ActionResult Index(string msg)
        {
            var list = scoreRepository.getAll();
            ViewBag.MSG = msg;
            ViewBag.listStudent = userRepository.getListStudent();
            ViewBag.listSubject = subjectRepository.getAll();
            return View(list);
        }

        public ActionResult Add(FormCollection form)
        {
            Score score = new Score();
            score.id_user = Int32.Parse(form["name"]);
            score.id_subject = Int32.Parse(form["subject"]);
            score.point = float.Parse(form["point"]);

            var obj = scoreRepository.checkPointExist(score);
            if (obj == null)
            {
                scoreRepository.add(score);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
          
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            scoreRepository.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(FormCollection form)
        {
            Score score = new Score();
            score.id_user = Int32.Parse(form["student"]);
            score.id_subject = Int32.Parse(form["subject"]);
            score.point = float.Parse(form["point"]);
            scoreRepository.update(score);
            return RedirectToAction("Index", new { msg = "1" });
           
        }

        public ActionResult ListScoreForStudent(int id)
        {
            var listScore = scoreRepository.getListScoreById(id);
            return View(listScore);
        }
    }
}