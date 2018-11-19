using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework7.Models;
using System.Data.Entity;

namespace Homework7.DAL
{
   
        public class DbLogContext : DbContext
        {


            public DbLogContext() : base("name=request")
            {

            }

            /// <summary>
            /// Tells you what you can do with the db whether to get information from it or set information in it. 
            /// </summary>
            public virtual DbSet<Requestlist> Logs { get; set; }

        }
    }