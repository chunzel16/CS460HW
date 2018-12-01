using Homework8.Models;
using Homework8.Models.ViewModel;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private AuctionContext db = new AuctionContext();
        public JsonResult ItemBids(int? id)
        {

            Auctionvm vm = new Auctionvm
            {
                //Find the Item with the id
                VmItem = db.Items.Find(id)
            };

            string jsonObj = "";
            if (vm.VmItem.Bids.Count > 0)
            {
                int pid = vm.VmItem.Bids.FirstOrDefault().ItemID;
                vm.VmBid = db.Items.SelectMany(x => x.Bids)
                                    .Where(i => i.ItemID == pid)
                                    .OrderBy(t => t.TimeStamp)
                                    .ToList();

                jsonObj = JsonConvert.SerializeObject(vm.VmBid);
            }
            return Json(jsonObj, JsonRequestBehavior.AllowGet);

        }
    }
}