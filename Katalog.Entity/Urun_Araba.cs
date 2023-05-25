using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Urun_Araba : IEntity
    {
        public long Urun_ArabaID { get; set; }
        public long UrunID { get; set; }
        public long MarkaID { get; set; }
        public long TipID { get; set; }
        public long ModelID { get; set; }

    }
}