using MusiCodeWebApp.Areas.ManagerPanel.Data;
using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            if (Request.Cookies["UserCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["UserCookie"];
                string mail = SavedCookie.Values["mail"];
                string password = SavedCookie.Values["password"];

                User u = db.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                if (u != null)
                {
                    if (u.IsActive)
                    {
                        Session["UserSession"] = u;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User u = db.Users.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (u != null)
                {
                    if (u.IsActive)
                    {
                        if (model.RememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("UserCookie");
                            cookie["mail"] = model.Mail;
                            cookie["password"] = model.Password;
                            cookie.Expires = DateTime.Now.AddDays(10);
                            Response.Cookies.Add(cookie);
                        }
                        Session["UserSession"] = u;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.mesaj = "Kullanıcı hesabınız askıya alınmıştır";
                    }
                }
                else
                {
                    ViewBag.mesaj = "Kullanıcı bulunamadı";
                }
            }
            return View(model);

        }
        public ActionResult Logout()
        {
            Session["UserSession"] = null;
            if (Request.Cookies["UserCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["UserCookie"];
                SavedCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(SavedCookie);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User model)
        {
            if (db.Users.FirstOrDefault(x => x.Mail == model.Mail) == null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        model.CreationDate = DateTime.Now;
                        model.IsDeleted = false;
                        model.IsActive = true;
                        model.UserRoleID = 1;
                        db.Users.Add(model);
                        db.SaveChanges();
                        Session["UserSession"] = model.ID;
                        TempData["mesaj"] = "Kayıt oluşturma başarılı";
                        return RedirectToAction("Index", "Home");
                    }
                    catch
                    {
                        ViewBag.mesaj = "Bir hata oluştu";
                    }
                }
            }
            else
            {
                ViewBag.mesaj = "Bu mail zaten kayıtlı! Farklı bir mail adresi giriniz";
                return View();
            }
            return View(model);
        }
    }
}
