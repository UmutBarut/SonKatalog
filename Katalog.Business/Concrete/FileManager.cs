using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Helpers.File;
using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly UserManager<Kullanici> _userManager;
        private Kullanici kullanici;
        private readonly IUrunService _urunService;
        private readonly IMarkaService _markaService;
        private readonly IFileHelper _fileHelper;

        public FileManager(UserManager<Kullanici> userManager,IUrunService urunService, IMarkaService markaService, IFileHelper fileHelper)
        {
            _userManager = userManager;
            _urunService = urunService;
            _markaService = markaService;
            _fileHelper = fileHelper;
        }

           public async Task<IResult> Add(IFormFile file, Kullanici kullanici)
        {
            string folderName = "avatars";
            if (!string.IsNullOrEmpty(kullanici.ImagePath))
            {
                _fileHelper.Remove(kullanici.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            kullanici.ImagePath = imageResult.Message;
            await _userManager.UpdateAsync(kullanici);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<IResult> AddForUrun(IFormFile file, Urun urun)
        {
            string folderName ="urunler";
             if (!string.IsNullOrEmpty(urun.ImagePath))
            {
                _fileHelper.Remove(urun.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            urun.ImagePath = imageResult.Message;
            _urunService.Update(urun);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

        public async Task<IResult> AddForMarka(IFormFile file, Marka marka)
        {
            string folderName ="markalar";
             if (!string.IsNullOrEmpty(marka.ImagePath))
            {
                _fileHelper.Remove(marka.ImagePath,folderName);
            }
            var imageResult = _fileHelper.Upload(file,folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }

            marka.ImagePath = imageResult.Message;
            _markaService.Update(marka);
            return new SuccessResult("Resim Başarıyla Yüklendi");
        }

    }
}