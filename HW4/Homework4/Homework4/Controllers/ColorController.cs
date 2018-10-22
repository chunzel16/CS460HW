using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Converter
        [HttpGet]
        public ActionResult MixColor()
        {
            ViewBag.show = false;
            return View();
        }
        [HttpPost]
        public ActionResult MixColor(string FirstColor, string SecondColor)
        {
            //Get the inputs
            FirstColor = Request.Form["FirstColor"];
            SecondColor = Request.Form["SecondColor"];

            //make sure the color input are not null
            if (FirstColor != null && SecondColor != null)
            {
                ViewBag.show = true;
                Color FirstInput = ColorTranslator.FromHtml(FirstColor);
                Color SecondInput = ColorTranslator.FromHtml(SecondColor);

                //Calculate new color
                Color MixedColor = new Color();

                //Initialize RGB
                int red, green, blue = 0;

                //Make sure the value <= 255
                if (FirstInput.R + SecondInput.R > 255)
                {
                    red = 255;
                }
                else
                {
                    red = FirstInput.R + SecondInput.R;
                }

                if (FirstInput.G + SecondInput.G > 255)
                {
                    green = 255;
                }
                else
                {
                    green = FirstInput.G + SecondInput.G;
                }

                if (FirstInput.B + SecondInput.B > 255)
                {
                    blue = 255;
                }
                else
                {
                    blue = FirstInput.B + SecondInput.B;
                }

                //define MixedColor
                MixedColor = Color.FromArgb(255, red, green, blue);
                //define the result to ResultColor
                string ResultColor = ColorTranslator.ToHtml(MixedColor);

                //Return all three color 
                ViewBag.color1 = "background:" + FirstColor;
                ViewBag.color2 = "background:" + SecondColor;
                ViewBag.newcolor = "background:" + ResultColor;
            }
            return View();
        }
    }
}