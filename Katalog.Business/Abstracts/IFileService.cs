using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Katalog.Business.Abstracts
{
    public interface IFileService
    {
       Task<IResult> Add(IFormFile dosya, Kullanici kullanici);
       Task<IResult> AddForUrun(IFormFile dosya,Urun urun);
       Task<IResult> AddForMarka(IFormFile dosya,Marka marka);
    }
}