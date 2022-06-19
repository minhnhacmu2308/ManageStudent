using ManagementStudent.Models;
using ManagementStudent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementStudent.Controllers
{
    public class PostController : Controller
    {
        PostRepository postRepository = new PostRepository();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = postRepository.getAll();
            ViewBag.MSG = msg;
            return View();
        }

        public ActionResult TinTuc()
        {
            ViewBag.List = postRepository.getAll();
            return View();
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            postRepository.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Post post)
        {
            post.created = DateTime.Now;
            postRepository.add(post);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Post post)
        {
            postRepository.update(post);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}