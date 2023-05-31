using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Katalog.Entity;
using Katalog.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Katalog.ViewModels;
using Katalog.Dataaccess.Concrete.Contexts;
using Katalog.Entity.Views;
using Microsoft.AspNetCore.Authorization;

namespace Katalog.Controllers
{
    [AllowAnonymous]
    public class KatalogController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IOEMService _oemService;
        private readonly IFirmaService _firmaService;
        private readonly IMarkaService _markaService;
        private readonly ITipService _tipService;
        private readonly IModelService _modelService;
        private readonly IReferansService _referansService;
        private readonly IUyumlulukService _uyumlulukService;
        private readonly IKullanilanParcaService _kullanilanParcaService;
        public KatalogController(IUrunService urunService, IFirmaService firmaService, IMarkaService markaService, ITipService tipService, IModelService modelService, IOEMService oemService, IReferansService referansService, IUyumlulukService uyumlulukService, IKullanilanParcaService kullanilanParcaService)
        {
            _urunService = urunService;
            _firmaService = firmaService;
            _markaService = markaService;
            _tipService = tipService;
            _modelService = modelService;
            _oemService = oemService;
            _referansService = referansService;
            _uyumlulukService = uyumlulukService;
            _kullanilanParcaService = kullanilanParcaService;
        }

        public IActionResult KatalogListe(string? search, int markaId, int tipId, int modelId)
        {

            AjaxViewModel model = new()
            {
                Markalar = _markaService.MarkaList().Data,
                Urunler = _urunService.UrunList().Data
            };

            if (search != null)
            {
                using (var Contexts = new ApplicationDbContext())
                {
                    var query = @$"
                    SELECT urunler.Price ,urunler.UrunID, urunler.UrunNo, urunler.UrunAdi, urunler.Olculer, oemler.OEMno, urunler.ImagePath FROM urunler
                    LEFT JOIN oemler ON(urunler.UrunID = oemler.UrunID)
                    LEFT JOIN uyumluluklar ON(uyumluluklar.UrunID = urunler.UrunID)
                    LEFT JOIN modeller ON(modeller.ModelID = uyumluluklar.ModelID)
                    LEFT JOIN markalar ON(markalar.MarkaID = modeller.MarkaID)
                    LEFT JOIN tipler ON(tipler.TipID = modeller.TipID)
                    LEFT JOIN referanslar ON(urunler.UrunID = referanslar.UrunID)
                    LEFT JOIN firmalar  ON(referanslar.FirmaID = firmalar.FirmaID)
                    WHERE urunler.UrunNo LIKE '{search}'
                    OR urunler.UrunAdi LIKE'{search}'
                    OR urunler.Price LIKE'{search}'
                    OR urunler.Olculer LIKE'{search}'
                    OR urunler.EANno LIKE'{search}'
                    OR oemler.OEMno LIKE'{search}'
                    OR markalar.MarkaAdi LIKE'{search}'
                    OR tipler.TipAdi LIKE'{search}'
                    OR modeller.ModelAdi LIKE'{search}'
                    or referanslar.RefNo LIKE'{search}'
                    ";
                    var list = Contexts.searchresults.FromSqlRaw(query).GroupBy(x => x.UrunNo).Select(x => x.FirstOrDefault()).ToList();
                    model.searchresults = list;
                    return View(model);
                }
            }

            using (var context = new ApplicationDbContext())
            {
                if (markaId != 0)
                {
                    if (tipId != 0)
                    {
                        if (modelId != 0)
                        {
                            var query = @$"
                            SELECT urunler.UrunID, urunler.UrunNo , urunler.UrunAdi , urunler.Olculer , oemler.OEMno , urunler.ImagePath FROM urunler
                            LEFT JOIN oemler ON(urunler.UrunID = oemler.UrunID)
                            LEFT JOIN markalar ON(markalar.MarkaID = oemler.MarkaID)
                            LEFT JOIN tipler ON(tipler.MarkaID = markalar.MarkaID)
                            LEFT JOIN modeller ON(modeller.TipID = tipler.TipID)
                            LEFT JOIN referanslar ON(urunler.UrunID = referanslar.UrunID)
                            LEFT JOIN firmalar ON(referanslar.FirmaID = firmalar.FirmaID)
                            WHERE markalar.MarkaID = '{markaId}' AND tipler.TipID = {tipId} AND modeller.ModelID = {modelId}
                            ";
                            var list = context.searchresults.FromSqlRaw(query).GroupBy(x => x.UrunNo).Select(x => x.FirstOrDefault()).ToList();
                            model.searchresults = list;
                            return View(model);
                        }
                        else
                        {
                            var query = @$"
                            SELECT urunler.UrunID, urunler.UrunNo , urunler.UrunAdi , urunler.Olculer , oemler.OEMno , urunler.ImagePath FROM urunler
                            LEFT JOIN oemler ON(urunler.UrunID = oemler.UrunID)
                            LEFT JOIN markalar ON(markalar.MarkaID = oemler.MarkaID)
                            LEFT JOIN tipler ON(tipler.MarkaID = markalar.MarkaID)
                            LEFT JOIN modeller ON(modeller.TipID = tipler.TipID)
                            LEFT JOIN referanslar ON(urunler.UrunID = referanslar.UrunID)
                            LEFT JOIN firmalar ON(referanslar.FirmaID = firmalar.FirmaID)
                            WHERE markalar.MarkaID = '{markaId}' AND tipler.TipID = {tipId}
                            ";
                            var list = context.searchresults.FromSqlRaw(query).GroupBy(x => x.UrunNo).Select(x => x.FirstOrDefault()).ToList();
                            model.searchresults = list;
                            return View(model);
                        }
                    }
                    else
                    {
                        var query = @$"
                            SELECT urunler.UrunID, urunler.UrunNo , urunler.UrunAdi , urunler.Olculer , oemler.OEMno , urunler.ImagePath FROM urunler
                            LEFT JOIN oemler ON(urunler.UrunID = oemler.UrunID)
                            LEFT JOIN markalar ON(markalar.MarkaID = oemler.MarkaID)
                            LEFT JOIN tipler ON(tipler.MarkaID = markalar.MarkaID)
                            LEFT JOIN modeller ON(modeller.TipID = tipler.TipID)
                            LEFT JOIN referanslar ON(urunler.UrunID = referanslar.UrunID)
                            LEFT JOIN firmalar ON(referanslar.FirmaID = firmalar.FirmaID)
                            WHERE markalar.MarkaID = '{markaId}'
                            ";
                        var list = context.searchresults.FromSqlRaw(query).GroupBy(x => x.UrunNo).Select(x => x.FirstOrDefault()).ToList();
                        model.searchresults = list;
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        public async Task<List<Tip>> TipGetiren(long getiren)
        {
            var tipler = _tipService.TipList(c => c.MarkaID == getiren).Data;


            return tipler;
        }

        public async Task<List<Model>> ModelGetiren(long getiren)
        {
            var modeller = _modelService.ModelList(c => c.TipID == getiren).Data;

            return modeller;
        }




        public IActionResult UrunDetay(long id)
        {
            using (var Contexts = new ApplicationDbContext())
            {
                UrunDetayViewModel model = new()
                {
                    detaytablosu = Contexts.detaytablosu.ToList(),
                    urun = _urunService.GetById(c => c.UrunID == id).Data,
                    Firmalar = _firmaService.FirmaList().Data,
                    Markalar = _markaService.MarkaList().Data,
                    OEMLER = _oemService.OEMList().Data,
                    Tipler = _tipService.TipList().Data,
                    Uyumluluklar = _uyumlulukService.UyumlulukList().Data,
                    Modeller = _modelService.ModelList().Data,
                    Referanslar = _referansService.ReferansList().Data,
                    kullanilanParcalar = _kullanilanParcaService.KullanilanParcaList().Data,
                };

                return View(model);
            }




        }
    }
}