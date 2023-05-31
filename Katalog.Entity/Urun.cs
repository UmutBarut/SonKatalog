using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Urun : IEntity
    {
        [Key]
        public long UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunNo { get; set; }
        public string Olculer { get; set; }
        public long EANno { get; set; }
        public string? EslestirilenUrunNo { get; set; }
        public long? KullanildigiParcaID { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
        public string? ImagePath { get; set; }
        public int? Price { get; set; }

      
    }
}