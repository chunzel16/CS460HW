using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModel
{
    public class Auctionvm
    {
        public Item VmItem { get; set; }

        public List<Bid> VmBid { get; set; }
    }
}
