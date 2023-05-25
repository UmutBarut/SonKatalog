using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;

namespace Katalog.Business.Concrete
{
    public class UyumlulukManager : IUyumlulukService
    {
        private readonly IUyumlulukDal _uyumlulukDal;

        public UyumlulukManager(IUyumlulukDal uyumlulukDal)
        {
            _uyumlulukDal = uyumlulukDal;
        }
        public IResult Add(Uyumluluk uyumluluk)
        {
            _uyumlulukDal.InsertAsync(uyumluluk);
            return new SuccessResult();
        }

        public IResult Delete(Uyumluluk uyumluluk)
        {
            _uyumlulukDal.Delete(uyumluluk);
            return new SuccessResult();
        }

         public IDataResult<Uyumluluk> GetById(Expression<Func<Uyumluluk, bool>> expression)
        {
            return new SuccessDataResult<Uyumluluk>(_uyumlulukDal.GetAll(expression).First());
        }

        public IDataResult<List<Uyumluluk>> UyumlulukList(Expression<Func<Uyumluluk, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Uyumluluk>>(_uyumlulukDal.GetAll());
            }
            return new SuccessDataResult<List<Uyumluluk>>(_uyumlulukDal.GetAll(expression));
        }

        public IResult Update(Uyumluluk uyumluluk)
        {
            _uyumlulukDal.Update(uyumluluk);
            return new SuccessResult();
        }
    }
}