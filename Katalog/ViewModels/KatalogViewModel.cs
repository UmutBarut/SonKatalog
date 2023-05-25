using Katalog.Entity;

namespace Katalog.ViewModels
{
    public class KatalogViewModel
    
    { 
        public List<Urun> Urunler { get; set;}
        public List<Marka> Markalar { get; set; }
        public List<Tip> Tipler { get; set; }
        public List<Model> Modeller { get; set; }
        public List<Uyumluluk> Uyumluluklar { get; set; }
        public List<Firma> Firmalar { get; set; }
        public List<OEM> OEMLER { get; set; }
        public List<Referans> Referanslar { get; set; }
        public List<KullanilanParca> KullanilanParcalar { get; set; }
        
        


    }
}