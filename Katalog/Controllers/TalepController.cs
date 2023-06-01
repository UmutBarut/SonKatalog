using Katalog.Business.Abstracts;
using Katalog.Dataaccess.Abstracts;
using Katalog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.Controllers
{
	public class TalepController : Controller
	{
		private readonly IUrunDal _urunDal;
        private readonly IFirmaService _firmaService;
        private readonly IMarkaService _markaService;
        private readonly ITipService _tipService;
        private readonly IModelService _modelService;
        private readonly IOEMService _oemService;
        private readonly IReferansService _referansService;
        private readonly IUyumlulukService _uyumlulukService;
        private readonly IFileService _fileService;

        public TalepController(IUrunDal urunDal, IFirmaService firmaService, IMarkaService markaService, ITipService tipService, IModelService modelService, IOEMService oemService, IReferansService referansService, IUyumlulukService uyumlulukService, IFileService fileService)
		{
			_urunDal = urunDal;
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
            var vm = new UrunViewModel()
            {
                Markalar = _markaService.MarkaList().Data,
                Tipler = _tipService.TipList().Data,
                Modeller = _modelService.ModelList().Data
            };
            return View(vm);
		}
	}
}