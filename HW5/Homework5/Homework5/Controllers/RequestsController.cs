using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using Homework5.DAL;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class RequestsController : Controller
    {
        private RequestContext db = new RequestContext();
        // GET: Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}