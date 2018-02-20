using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularzZDataBase.Models
{
    public class AdressContext : DbContext
    {
        public AdressContext() : base("Addressess")
        {
       
        }

        public DbSet<Address> Addresses { get; set; }
    }
}