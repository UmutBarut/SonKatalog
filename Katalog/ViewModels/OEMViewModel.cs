using Katalog.Entity;

namespace Katalog.ViewModels
{
    public class OEMViewModel
    {
        public List<Urun> Urunler { get; set; }
        public List<Marka> Markalar { get; set; }
        public List<OEM> OEMler { get; set; }
    }
}