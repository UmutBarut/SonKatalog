using Katalog.Entity;
using Katalog.Entity.Views;

namespace Katalog.ViewModels
{
    public class AjaxViewModel
    {
        public List<searchresult>? searchresults { get; set; }
        public List<Marka>? Markalar { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}