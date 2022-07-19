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
        CreditRepository creditRepository = new CreditRepository();
        // GET: Score
        public ActionResult Index(string msg)
        {
            var list = scoreRepository.getAll();
            ViewBag.MSG = msg;
            ViewBag.listStudent = userRepository.getListStudent();
            ViewBag.listSubject = subjectRepository.getAll();
            return View(list);
        }
        public ActionResult Rank()
        {
            ViewBag.Rank = scoreRepository.getRank();
            return View();
        }
        public ActionResult Add(FormCollection form)
        {
            int idSubject = Int32.Parse(form["idSubject"]);
            var listSv = creditRepository.getSub(idSubject);
          /*  var check = new ManagementStudent.Repositories.ScoreRepository().getScoreByIdAndIdSubject(sv.User.id_user, item.id_subject);*/
            /*   listSv.Where(x => scoreRepository.getScoreByIdAndIdSubject(x.id_user,x.id_subject) == null).ToList();*/
            List<Score> scores = new List<Score>();
            for (int i = 0; i< listSv.Count; i++)
            {
                var check = scoreRepository.getScoreByIdAndIdSubject(listSv[i].id_user, idSubject);
                if (check == null)
                {
                    var nameIdUser = "idUser" + listSv[i].id_user;
                    var namePoint1 = "point1" + listSv[i].id_user;
                    var namePoint2 = "point2" + listSv[i].id_user;
                    int idUser = Int32.Parse(form[nameIdUser]);
                    int point1 = Int32.Parse(form[namePoint1]);
                    int point2 = Int32.Parse(form[namePoint2]);
                    scores.Add(new Score() { id_user = idUser, point = point1, point2 = point2, id_subject = idSubject });
                }          
            }
            if(scores != null && scores.Count > 0)
            {
                scores.ForEach(x => scoreRepository.add(x));
                return RedirectToAction("Index", new { msg = "1" });
            }
            return RedirectToAction("Index", new { msg = "1" });
            /* Score score = new Score();
             score.id_user = Int32.Parse(form["name"]);
             score.id_subject = Int32.Parse(form["subject"]);
             score.point = float.Parse(form["point"]);
             score.point2 = float.Parse(form["point2"]);
             var obj = scoreRepository.checkPointExist(score);
             if (obj == null)
             {
                 scoreRepository.add(score);
                 return RedirectToAction("Index", new { msg = "1" });
             }
             else
             {
                 return RedirectToAction("Index", new { msg = "2" });
             }         */
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
            score.point2 = float.Parse(form["point2"]);
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