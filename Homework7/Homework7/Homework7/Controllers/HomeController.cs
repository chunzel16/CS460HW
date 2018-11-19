using Homework7.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        private DbLogContext db = new DbLogContext();

        public JsonResult Sticker(string txt)
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKEY"];
            string getURL = "https://api.giphy.com/v1/stickers/translate?api_key="+apiKey+"&s=" + txt;
            Debug.WriteLine(getURL);
            WebRequest request = WebRequest.Create(getURL);
            WebResponse getResponce = request.GetResponse();
            var dbContext = db.Logs.Create();

            dbContext.AccessTime = DateTime.Now;
            dbContext.IPAddress = Request.UserHostAddress;
            dbContext.Request = txt;
            dbContext.ClientBrowser = Request.UserAgent;
            db.Logs.Add(dbContext);
            db.SaveChanges();
            Stream data = request.GetResponse().GetResponseStream();
            string convString = new StreamReader(data).ReadToEnd();
            var serialize = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonObj = serialize.DeserializeObject(convString);
            data.Close();
            getResponce.Close();

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }
    }
}