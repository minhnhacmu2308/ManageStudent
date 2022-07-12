using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        public ActionResult Trash()
        {
            return View();
        }

        public ActionResult Class(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = userRepository.getClass(lop);
                ViewBag.lop = lop;
                return View();
            }
            else
            {
                ViewBag.List = null;
                return View();
            }
        }

        public ActionResult Export(string lop)
        {
            List<User> sv = userRepository.getClass(lop);
            var abc = sv.Select(x => new SinhVienDto
            {
                MaSinhVien = "SV_2022_" + x.id_user,
                HoTen = x.fullname,
                GioiTinh = x.gender == 0 ? "Nữ" : "Nam",
                Nganh = x.Majors.name

            }).ToList();
            //Export
            var gv = new GridView();
            gv.DataSource = abc;
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            // "attachment;filename=GridViewExport.xls");
            Response.Charset = "utf-8";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=ThongKe.xls");
            //Mã hóa chữ sang UTF8
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                //Apply text style to each Row
                gv.Rows[i].Attributes.Add("class", "textmode");
            }
            //Add màu nền cho header của file excel
            gv.HeaderRow.BackColor = System.Drawing.Color.DarkBlue;
            //Màu chữ cho header của file excel
            gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

            gv.HeaderRow.Cells[0].Text = "Mã sinh viên";
            gv.HeaderRow.Cells[1].Text = "Họ tên";
            gv.HeaderRow.Cells[2].Text = "Giới tính";
            gv.HeaderRow.Cells[3].Text = "Ngành";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }

        public ActionResult Khoas(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = userRepository.getListStudent();
                ViewBag.lop = lop;
                return View();
            }
            else
            {
                ViewBag.List = null;
                return View();
            }
        }

        public ActionResult ExportK(string lop)
        {
            List<User> sv = userRepository.getListStudent();
            var abc = sv.Select(x => new SinhVienKhoasDto
            {
                MaSinhVien = "SV_2022_" + x.id_user,
                HoTen = x.fullname,
                GioiTinh = x.gender == 0 ? "Nữ" : "Nam",
                Lop = x.grade,
                Nganh = x.Majors.name,
                Khoa = lop

            }).ToList();
            //Export
            var gv = new GridView();
            gv.DataSource = abc;
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            // "attachment;filename=GridViewExport.xls");
            Response.Charset = "utf-8";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=ThongKe.xls");
            //Mã hóa chữ sang UTF8
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                //Apply text style to each Row
                gv.Rows[i].Attributes.Add("class", "textmode");
            }
            //Add màu nền cho header của file excel
            gv.HeaderRow.BackColor = System.Drawing.Color.DarkBlue;
            //Màu chữ cho header của file excel
            gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

            gv.HeaderRow.Cells[0].Text = "Mã sinh viên";
            gv.HeaderRow.Cells[1].Text = "Họ tên";
            gv.HeaderRow.Cells[2].Text = "Giới tính";
            gv.HeaderRow.Cells[3].Text = "Lớp";
            gv.HeaderRow.Cells[3].Text = "Ngành";
            gv.HeaderRow.Cells[3].Text = "Khóa";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }

        public ActionResult Khoa(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = userRepository.getListStudent();
                ViewBag.lop = lop;
                return View();
            }
            else
            {
                ViewBag.List = null;
                return View();
            }
        }

        public ActionResult ExportKh(string lop)
        {
            List<User> sv = userRepository.getListStudent();
            var abc = sv.Select(x => new SinhVienKhoasDto
            {
                MaSinhVien = "SV_2022_" + x.id_user,
                HoTen = x.fullname,
                GioiTinh = x.gender == 0 ? "Nữ" : "Nam",
                Lop = x.grade,
                Nganh = x.Majors.name,
                Khoa = lop

            }).ToList();
            //Export
            var gv = new GridView();
            gv.DataSource = abc;
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            // "attachment;filename=GridViewExport.xls");
            Response.Charset = "utf-8";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=ThongKe.xls");
            //Mã hóa chữ sang UTF8
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                //Apply text style to each Row
                gv.Rows[i].Attributes.Add("class", "textmode");
            }
            //Add màu nền cho header của file excel
            gv.HeaderRow.BackColor = System.Drawing.Color.DarkBlue;
            //Màu chữ cho header của file excel
            gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

            gv.HeaderRow.Cells[0].Text = "Mã sinh viên";
            gv.HeaderRow.Cells[1].Text = "Họ tên";
            gv.HeaderRow.Cells[2].Text = "Giới tính";
            gv.HeaderRow.Cells[3].Text = "Lớp";
            gv.HeaderRow.Cells[3].Text = "Ngành";
            gv.HeaderRow.Cells[3].Text = "Khoa";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }

        public ActionResult Major(FormCollection form)
        {
            var nganh = form["nganh"];
            if (nganh != null)
            {
                var nganhid = Int32.Parse(form["nganh"]);
                ViewBag.List = userRepository.getMajor(nganhid);
                ViewBag.nganh = nganhid;
            }
            else
            {
                ViewBag.List = null;
            }
            ViewBag.listMajor = majorRepository.GetAll();
            return View();
        }

        public ActionResult Exports(int id)
        {
            List<User> sv = userRepository.getMajor(id);
            var abc = sv.Select(x => new SinhVienSDto
            {
                MaSinhVien = "SV_2022_" + x.id_user,
                HoTen = x.fullname,
                GioiTinh = x.gender == 0 ? "Nữ" : "Nam",
                Lop = x.grade

            }).ToList();
            //Export
            var gv = new GridView();
            gv.DataSource = abc;
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            // "attachment;filename=GridViewExport.xls");
            Response.Charset = "utf-8";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=ThongKe.xls");
            //Mã hóa chữ sang UTF8
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                //Apply text style to each Row
                gv.Rows[i].Attributes.Add("class", "textmode");
            }
            //Add màu nền cho header của file excel
            gv.HeaderRow.BackColor = System.Drawing.Color.DarkBlue;
            //Màu chữ cho header của file excel
            gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

            gv.HeaderRow.Cells[0].Text = "Mã sinh viên";
            gv.HeaderRow.Cells[1].Text = "Họ tên";
            gv.HeaderRow.Cells[2].Text = "Giới tính";
            gv.HeaderRow.Cells[3].Text = "Lớp";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
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