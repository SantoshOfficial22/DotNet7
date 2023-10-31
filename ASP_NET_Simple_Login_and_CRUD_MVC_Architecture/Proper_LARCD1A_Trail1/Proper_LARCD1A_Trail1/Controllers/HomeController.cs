using BusinessAccessLayer.Abstract;
using BusinessAccessLayer.Implementation;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proper_LARCD1A_Trail1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginAndRegistration _loginAndRegistration;
        public HomeController()
        {
            _loginAndRegistration = new LoginAndRegistration();
        }
        public HomeController(ILoginAndRegistration loginAndRegistration)
        {
            _loginAndRegistration = loginAndRegistration;
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]	
        public ActionResult Register(LoginAndRegistrationModel loginAndRegistration)
        {
          

            if (_loginAndRegistration.Register(loginAndRegistration))
            {
                ViewBag.Message = "Successfully Added";
                return View();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Login(LoginAndRegistrationModel loginAndRegistration)
        {
            if (_loginAndRegistration.Login(loginAndRegistration))
            {
                Session["Email"] = loginAndRegistration.Email;
                return RedirectToAction("GetList", "Library");
            }
            else
            {
                ViewBag.Message = "Enter correct details";
                return View();
            }
        }






        //Normal Build.........................
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }             

    }
}