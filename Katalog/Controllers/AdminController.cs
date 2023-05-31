using Katalog.Entity;
using Katalog.Business.Abstracts;


using Microsoft.AspNetCore.Mvc;
using Katalog.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Katalog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IFirmaService _firmaService;
        private readonly IMarkaService _markaService;
        private readonly ITipService _tipService;
        private readonly IModelService _modelService;
        private readonly IOEMService _oemService;
        private readonly IReferansService _referansService;
        private readonly IUyumlulukService _uyumlulukService;
        private readonly IFileService _fileService;



        public AdminController(IUrunService urunService, IFirmaService firmaService, IMarkaService markaService, ITipService tipService, IModelService modelService, IOEMService oemService, IReferansService referansService, IUyumlulukService uyumlulukService, IFileService fileService)
        {
            _urunService = urunService;
            _firmaService = firmaService;
            _markaService = markaService;
            _tipService = tipService;
            _modelService = modelService;
            _oemService = oemService;
            _referansService = referansService;
            _uyumlulukService = uyumlulukService;
            _fileService = fileService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = _urunService.GetById(c => c.UrunID == id);

            if (urun == null)
            {
                return NotFound();
            }

            var model = new UrunViewModel()
            {
                UrunID = urun.Data.UrunID,
                UrunNo = urun.Data.UrunNo,
                UrunAdi = urun.Data.UrunAdi,
                Olculer = urun.Data.Olculer,
                EANno = urun.Data.EANno,
                ImagePath = urun.Data.ImagePath,
                EslestirilenUrunNo = urun.Data.EslestirilenUrunNo
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IFormFile file, Urun urun)
        {
            var urunler = _urunService.GetById(c => c.UrunID == urun.UrunID);

            if (urunler == null)
            {
                return NotFound();
            }

            if (urunler != null)
            {
                _urunService.Update(urun);
                _fileService.AddForUrun(file, urun);
            }

           return RedirectToAction("KatalogListe","Katalog");
        }

        public IActionResult Delete(Urun urun)
        {
            var urunler = _urunService.GetById(c => c.UrunID == urun.UrunID);

            if (urunler != null)
            {
                _urunService.Delete(urun);
            }

            return RedirectToAction("Katalogliste","Katalog");


        }

        public IActionResult UrunTanimlama()
        {
            var vm = new UrunViewModel()
            {
                Markalar = _markaService.MarkaList().Data,
                Tipler = _tipService.TipList().Data,
                Modeller = _modelService.ModelList().Data
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult UrunTanimlama(IFormFile file, Urun urun, long[] ModelIDleri)
        {
            if (urun != null)
            {
                urun.Siralama = 1;
                urun.Pasif = false;
                _urunService.Add(urun);
                _fileService.AddForUrun(file, urun);
                foreach (var item in ModelIDleri)
                {
                    var model = _modelService.GetById(c => c.ModelID == item).Data;
                    var uyumluluk = new Uyumluluk()
                    {
                        ModelID = item,
                        Siralama = 1,
                        UrunID = urun.UrunID,
                        Uyum = "All Types",
                    };
                    _uyumlulukService.Add(uyumluluk);
                }
            }


            return RedirectToAction("Index");
        }

        public IActionResult FirmaTanimlama()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FirmaTanimlama(Firma firma)
        {
            firma.Siralama = 1;
            firma.Pasif = false;
            _firmaService.Add(firma);


            return RedirectToAction("Index");
        }

        public IActionResult MarkaTanimlama()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult MarkaTanimlama(IFormFile file,Marka marka)
        {
            marka.Siralama = 1;
            marka.Pasif = false;
            _fileService.AddForMarka(file,marka);
            _markaService.Add(marka);

            return RedirectToAction("Index");
        }

        public IActionResult TipTanimlama()
        {
            var marka = _markaService.MarkaList().Data;
            return View(marka);
        }

        [HttpPost]
        public IActionResult TipTanimlama(Tip tip)
        {
            tip.Siralama = 0;
            tip.Pasif = false;
            _tipService.Add(tip);
            return RedirectToAction("Index");
        }

        public IActionResult ModelTanimlama()
        {
            var model = _modelService.ModelList().Data;
            var tip = _tipService.TipList().Data;
            var marka = _markaService.MarkaList().Data;
            var vm = new ModelViewModel()
            {
                Modeller = model,
                Tipler = tip,
                Markalar = marka
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult ModelTanimlama(Model model)
        {
            model.Siralama = 1;
            model.Pasif = false;
            _modelService.Add(model);

            return RedirectToAction("Index");
        }

        public IActionResult OEMTanimlama()
        {
            var urun = _urunService.UrunList().Data;
            var marka = _markaService.MarkaList().Data;
            var oem = _oemService.OEMList().Data;
            var vm = new OEMViewModel()
            {
                Urunler = urun,
                Markalar = marka,
                OEMler = oem
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult OEMTanimlama(OEM oem)
        {
            oem.Siralama = 1;
            oem.Pasif = false;
            _oemService.Add(oem);

            return RedirectToAction("Index");
        }

        public IActionResult ReferansTanimlama()
        {
            var referans = _referansService.ReferansList().Data;
            var firma = _firmaService.FirmaList().Data;
            var urun = _urunService.UrunList().Data;
            var vm = new ReferansViewModel()
            {
                Referanlar = referans,
                Firmalar = firma,
                Urunler = urun
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult ReferansTanimlama(Referans referans)
        {

            referans.Siralama = 1;
            referans.Pasif = false;
            _referansService.Add(referans);
            return RedirectToAction("Index");
        }


        public IActionResult UyumlulukTanimlama()
        {
            var urun = _urunService.UrunList().Data;
            var marka = _markaService.MarkaList().Data;
            var tip = _tipService.TipList().Data;
            var model = _modelService.ModelList().Data;
            var uyumluluk = _uyumlulukService.UyumlulukList().Data;
            var vm = new UyumlulukViewModel()
            {
                Urunler = urun,
                Markalar = marka,
                Tipler = tip,
                Modeller = model,
                Uyumluluklar = uyumluluk
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult UyumlulukTanimlama(Uyumluluk uyumluluk)
        {
            uyumluluk.Siralama = 1;
            _uyumlulukService.Add(uyumluluk);

            return RedirectToAction("Index");
        }

    }
}