using Katalog.Entity;

namespace Katalog.ViewModels
{
    public class UyumlulukViewModel
    {
        public List<Urun> Urunler { get; set;}
        public List<Marka> Markalar { get; set; }
        public List<Tip> Tipler { get; set; }
        public List<Model> Modeller { get; set; }
        public List<Uyumluluk> Uyumluluklar { get; set; }
    }
}