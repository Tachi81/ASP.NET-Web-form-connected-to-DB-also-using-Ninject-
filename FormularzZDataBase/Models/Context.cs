using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularzZDataBase.Models
{
    public class Context : DbContext
    {
        public Context() : base("Addressess")
        {
       
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<People> People { get; set; }
    }
}