using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Converter()
        {
            //Input the miles
            string miles = Request.QueryString["mileInput"];
            //Input the metric
            string metric = Request.QueryString["units"];
            //Initializes input
            double newmile = 0;
            //Make sure the input is not null
            if (miles != null)
            {
                if (miles != "")
                {
                    newmile = Convert.ToDouble(miles);
                }
                else
                {
                    return View();
                }

                //Make sure what units user choose
                if (metric == "millimeters")
                {
                    newmile = newmile * 1609344.0;
                }
                else if (metric == "centimeters")
                {
                    newmile = newmile * 160934.4;
                }
                else if (metric == "meters")
                {
                    newmile = newmile * 1609.344;
                }
                else if (metric == "kilometers")
                {
                    newmile = newmile * 1.609344;
                }

                //Calculation result number
                string outputNumber = newmile.ToString();

                //Final output
                ViewBag.message = miles + " miles is equal to " + outputNumber + " " + metric;
            }
            return View();



        }
    }
}
