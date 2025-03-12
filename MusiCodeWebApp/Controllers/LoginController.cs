using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Controllers
{
    public class LoginController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Login()
        {
            if (Request.Cookies["UserCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["UserCookie"];
                string mail = SavedCookie.Values["mail"];
                string password = SavedCookie.Values["password"];

                Manager m = db.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["ManagerSession"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}