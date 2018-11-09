using Homework6.Models;
using Homework6.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// context file connect to db
        /// </summary>
        private WWIContext db = new WWIContext();
        public ActionResult Index(String input)
        {
            input = Request.QueryString["input"];
            if (input == null)
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
                return View(db.People.Where(search => search.FullName.Contains(input)).ToList());
            }
        }
        public ActionResult Details(int? id)
        {
            ViewModel vm = new ViewModel();
            vm.Person = db.People.Find(id);
            ViewBag.Isp = false;
            if (vm.Person.Customers2.Count() > 0)
            {
                ViewBag.IsP = true;
                int cid = vm.Person.Customers2.FirstOrDefault().CustomerID;
                vm.Customer = db.Customers.Find(cid);
                ViewBag.GrossSales = vm.Customer.Orders.SelectMany(il => il.Invoices).SelectMany(ils => ils.InvoiceLines).Sum(i => i.ExtendedPrice);
                ViewBag.GrossProfit = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(lp => lp.LineProfit);
                vm.InvoiceLine = vm.Customer.Orders.SelectMany(x => x.Invoices)
                                               .SelectMany(i => i.InvoiceLines)
                                               .OrderByDescending(i => i.LineProfit)
                                               .Take(10)
                                               .ToList();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

    }
}