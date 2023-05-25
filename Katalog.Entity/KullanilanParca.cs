using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Core.Entity;

namespace Katalog.Entity
{
    public class KullanilanParca : IEntity
    {
        public long UrunID { get; set; }
        public string UrunNo { get; set; }
        [Key]
        public long KullanildigiParcaID { get; set; }
        public string KullanildigiParcaAdi { get; set; }
        public string KullanildigiParcaUrunNo { get; set; }
        public string EslestirilenUrunNo { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}