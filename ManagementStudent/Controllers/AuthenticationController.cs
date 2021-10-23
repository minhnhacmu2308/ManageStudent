using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class AuthenticationController : Controller
    {
        AuthenticationRepository authenticationDao = new AuthenticationRepository();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var email = form["username"];
            var password = form["password"];
            bool checkLogin = authenticationDao.checkLogin(email, password);
            if (checkLogin)
            {
                var userInformation = authenticationDao.getInformationByUserName(email);
                Session.Add("USER", userInformation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/");
        }
    }
}