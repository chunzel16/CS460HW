using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework6.Models.ViewModel
{
    public class ViewModel
    {
        public Person Person { get; set; }

        public Customer Customer { get; set; }

        public List<InvoiceLine> InvoiceLine { get; set; }
    }
}