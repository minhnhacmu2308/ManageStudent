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
    public class FeedbackController : Controller
    {
        FeedbackRepository feedbackRepository = new FeedbackRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = feedbackRepository.getAll();
            return View();
        }

        public ActionResult ThongKe()
        {
            ViewBag.List = feedbackRepository.getAll();
            return View();
        }

        public ActionResult Export()
        {
            List<Feedback> sv = feedbackRepository.getAll();
            var abc = sv.Select(x => new FeedbackDto
            {
                TieuDe =  x.title,
                NoiDung = x.content,
                NguoiGui = x.User.fullname,
                NgayGui = x.created.ToString(),
                TinhTrang = "Chưa phản hồi"

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

            gv.HeaderRow.Cells[0].Text = "Tiêu đề";
            gv.HeaderRow.Cells[1].Text = "Nội dung";
            gv.HeaderRow.Cells[2].Text = "Người gửi";
            gv.HeaderRow.Cells[3].Text = "Ngày gửi";
            gv.HeaderRow.Cells[4].Text = "Tình trạng";
            gv.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Feedback feedback)
        {
            var user = (User)Session["USER"];
            feedback.id_user = user.id_user;
            feedback.created = DateTime.Now;
            feedbackRepository.add(feedback);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}