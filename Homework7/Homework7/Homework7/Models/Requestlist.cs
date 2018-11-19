using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework7.Models
{
    public class Requestlist
    {

        public int ID { get; set; }

        public DateTime AccessTime { get; set; }

        public string Request { get; set; }

        public string IPAddress { get; set; }

        public string ClientBrowser { get; set; }
    }
}