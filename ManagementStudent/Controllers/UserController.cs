using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: User
        public ActionResult Index(string msg)
        {
            var listStudent = userRepository.getListStudent();
            ViewBag.MSG = msg;
            return View(listStudent);
        }

        public ActionResult Infor()
        {
            var userInfomatiom = (User)Session["USER"];
            ViewBag.Profile = userRepository.getUserById(userInfomatiom.id_user);
            return View();
        }

        public ActionResult ListGiangVien(string msg)
        {
            ViewBag.MSG = msg;
            var listGiangVien = userRepository.getListGiangVien();
            return View(listGiangVien);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var id = form["id"];
            userRepository.delete(Int32.Parse(id));
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        public ActionResult DeleteGv(FormCollection form)
        {
            var id = form["id"];
            userRepository.delete(Int32.Parse(id));
            return RedirectToAction("ListGiangVien", new { msg = "1" });
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            User principal = new User(); 

            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role  = Int32.Parse(form["id_role"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            var obj = userRepository.checkExistName(form["username"]);
            if (obj == null)
            {
                userRepository.add(principal);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
           
        }

        [HttpPost]
        public ActionResult AddGiangVien(FormCollection form)
        {
            User principal = new User();

            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role = Int32.Parse(form["id_role"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            var obj = userRepository.checkExistName(form["username"]);
            if (obj == null)
            {
                userRepository.add(principal);
                return RedirectToAction("ListGiangVien", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("ListGiangVien", new { msg = "2" });
            }

        }


        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            User principal = new User();

            principal.id_user = Int32.Parse(form["id"]);
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role = Int32.Parse(form["id_role"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            userRepository.edit(principal);
            return RedirectToAction("Index", new { msg = "1" });          

        }

        [HttpPost]
        public ActionResult UpdateGiangVien(FormCollection form)
        {
            User principal = new User();

            principal.id_user = Int32.Parse(form["id"]);
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role = Int32.Parse(form["id_role"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            userRepository.edit(principal);
            return RedirectToAction("ListGiangVien", new { msg = "1" });

        }
    }
}