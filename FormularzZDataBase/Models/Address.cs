using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularzZDataBase.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNr { get; set; }
    }
}