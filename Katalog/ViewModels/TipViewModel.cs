using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.ViewModels
{
    public class TipViewModel
    {
        public long TipID { get; set; }
        public string TipAdi { get; set; }
        public long MarkaId { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }

    }
}