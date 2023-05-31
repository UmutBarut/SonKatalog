using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity.Views
{
    public class searchresult
    {
        public long UrunID { get; set; }
        public string UrunNo { get; set; }
        public string UrunAdi { get; set; }
        public string Olculer { get; set; }
        public string OEMno { get; set; }
        public string? ImagePath { get; set; }
        public int? Price { get; set; }

    }
}