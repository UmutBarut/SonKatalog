using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Entity;

namespace Katalog.ViewModels
{
    public class UrunViewModel
    {
        public long UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunNo { get; set; }
        public string Olculer { get; set; }
        public long EANno { get; set; }
        public string EslestirilenUrunNo { get; set; }
        public long KullanildigiParcaID { get; set; }
        public string? ImagePath { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }


       public List<Marka> Markalar { get; set; }
       public List<Tip> Tipler { get; set; }
       public List<Model> Modeller { get; set; }


    }
}