using Katalog.Core.Entity;

namespace Katalog.Entity.Views
{
    public class KatalogListe : IEntity
    {
        public string? Resim { get; set; }
        public long UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunNo { get; set; }
        public string Olculer { get; set; }
        public string OEMno { get; set; }
    }
}