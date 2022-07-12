using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        public ActionResult ThongKe(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = creditRepository.getAll();
                ViewBag.lop = lop;
                return View();
            }
            else
            {
                ViewBag.List = null;
                return View();
            }
        }

        public ActionResult Nam(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = creditRepository.getAll();
                ViewBag.lop = lop;
                return View();
            }
            else
            {
                ViewBag.List = null;
                return View();
            }
        }

        public ActionResult Hoc(FormCollection form)
        {
            var lop = form["lop"];
            if (lop != null)
            {
                ViewBag.List = creditRepository.getAll();
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
            List<Credit> sv = creditRepository.getAll();
            var abc = sv.Select(x => new CreditDto
            {
                MaSinhVien = "SV_2022_" + x.id_user,
                HoTen = x.User.fullname,
                Nganh = x.User.Majors.name,
                MonHoc = x.Subject.name,
                ThamSo = lop

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
            gv.HeaderRow.Cells[2].Text = "Ngành";
            gv.HeaderRow.Cells[3].Text = "Môn học đăng ký";
            gv.HeaderRow.Cells[4].Text = "";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }

    }
}