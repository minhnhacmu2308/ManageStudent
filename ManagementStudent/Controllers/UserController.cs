using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        MajorRepository majorRepository = new MajorRepository();
        ScoreRepository scoreRepository = new ScoreRepository();
        // GET: User
        public ActionResult Index(string msg)
        {
            var listStudent = userRepository.getListStudent();
            ViewBag.MSG = msg;
            ViewBag.listMajor = majorRepository.GetAll();
            return View(listStudent);
        }

        public ActionResult Infor(string msg)
        {
            var userInfomatiom = (User)Session["USER"];
            ViewBag.MSG = msg;
            ViewBag.Profile = userRepository.getUserById(userInfomatiom.id_user);
            return View();
        }

        public ActionResult ChangePassword(string msg)
        {
            var userInfomatiom = (User)Session["USER"];
            ViewBag.MSG = msg;
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
            principal.id_major = Int32.Parse(form["id_major"]);
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
            principal.id_major = 12;
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
            principal.id_major = Int32.Parse(form["id_major"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            principal.nguontuyen = form["nguontuyen"];
            principal.truongchuyen = form["truongchuyen"];
            principal.dantoc = form["dantoc"];
            principal.tongiao = form["tongiao"];
            principal.quoctinh = form["quoctinh"];
            principal.cmnd = form["cmnd"];
            principal.noicap = form["noicap"];
            principal.ngaycap = form["ngaycap"];
            principal.cannang = form["cannang"];
            principal.chieucao = form["chieucao"];
            principal.sonambodoi = form["sonambodoi"];
            principal.sonamtnxp = form["sonamtnxp"];
            userRepository.edit(principal);
            return RedirectToAction("Index", new { msg = "1" });          

        }

        [HttpPost]
        public ActionResult SVUpdate(FormCollection form)
        {
            User principal = new User();

            principal.id_user = Int32.Parse(form["id_user"]);
            principal.password = form["password"];
            
            userRepository.SVedit(principal);
            return RedirectToAction("Infor", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult UpdateGiangVien(FormCollection form)
        {
            User principal = new User();

            principal.id_user = Int32.Parse(form["id"]);
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_major = 12;
            principal.id_role = Int32.Parse(form["id_role"]);
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.grade = form["grade"];
            principal.status = 1;
            userRepository.edit(principal);
            return RedirectToAction("ListGiangVien", new { msg = "1" });

        }

        [HttpPost]
        public ActionResult Send(FormCollection form)
        {
            int idUser = Int32.Parse(form["id_user"]);
            string email = form["email"];
            var list = scoreRepository.getListScoreById(idUser);
            string html = "";
            for(int i = 0; i< list.Count; i++)
            {
                html += "<tr>" +
                    "<td>"+(i+1)+"</td>"+
                    "<td>" + list[i].Subject.name + "</td>" +
                    "<td>" + list[i].point + "</td>" +
                    "<td>" + list[i].point2 + "</td>" +
                    "</tr>";
            }
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/html/TemplateEmail.cshtml"));
            content = content.Replace("{{body}}", html);
            sendMail(email,content,idUser);
            return RedirectToAction("Index", new { msg = "1" });
        }


        public void sendMail(string email, string body, int id_user)
        {
            var user = userRepository.getUserById(id_user);
            var formEmailAddress = ConfigurationManager.AppSettings["FormEmailAddress"].ToString();
            var formEmailDisplayName = ConfigurationManager.AppSettings["FormEmailDisplayName"].ToString();
            var formEmailPassword = ConfigurationManager.AppSettings["FormEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPost"].ToString();
            bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            MailMessage message = new MailMessage(new MailAddress(formEmailAddress, formEmailDisplayName), new MailAddress(email));
            message.Subject = "Bảng điểm của sinh viên " + user.fullname;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(formEmailAddress, formEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }

    }
}