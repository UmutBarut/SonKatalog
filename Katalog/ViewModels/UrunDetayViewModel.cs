using Katalog.Entity;
using Katalog.Entity.Views;

namespace Katalog.ViewModels
{
    public class UrunDetayViewModel
    {
        public Urun urun { get; set; }
        public List<Firma> Firmalar { get; set; }
        public List<OEM> OEMLER { get; set; }
        public List<Referans> Referanslar { get; set; }
        public List<Uyumluluk> Uyumluluklar { get; set; }
        public List<Marka> Markalar { get; set; }
        public List<Tip> Tipler { get; set; }
        public List<Model> Modeller { get; set; }
        public List<KullanilanParca> kullanilanParcalar { get; set; }
        public  List<detaytablo> detaytablosu { get; set; }

        
        
        
      

    }
}