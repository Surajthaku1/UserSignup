using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSignup.Models;

namespace UserSignup.Controllers
{
    public class HomeController : Controller
    {
        dbuserEntities db = new dbuserEntities();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.Tblusers.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Tbluser tbluser)
        {
            if(db.Tblusers.Any(x=>x.username==tbluser.username))
            {
                ViewBag.Notification = "This account has already exist";
                return View();
            }
            else
            {
                db.Tblusers.Add(tbluser);
                db.SaveChanges();

                Session["IdSS"] = tbluser.Id.ToString();
                Session["usernameSS"] = tbluser.username.ToString();
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Tbluser tbluser)
        {
            var checklogin = db.Tblusers.Where(x => x.username.Equals(tbluser.username) && x.Password.Equals(tbluser.Password)).FirstOrDefault();
            if(checklogin != null)
            {
                Session["IdSS"] = tbluser.Id.ToString();
                Session["usernameSS"] = tbluser.username.ToString();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Notification = "Wrong username or password";
            }
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

       
    }
}