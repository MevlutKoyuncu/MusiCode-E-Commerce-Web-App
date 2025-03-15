using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Controllers
{
    
    public class ProductController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProducts()
        {
            return View(db.Products.Where(x => x.IsDeleted == false).ToList());
                
        }
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Product p = db.Products.Find(id);
                if (p != null)
                {
                    return View(p);
                }
            }
            return RedirectToAction("AllProducts", "Product");
        }
    }
}