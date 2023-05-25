using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Katalog.Business.Abstracts
{
    public interface IUyumlulukService
    {
        public IDataResult<List<Uyumluluk>> UyumlulukList(Expression<Func<Uyumluluk, bool>> expression = null);
        public IDataResult<Uyumluluk> GetById(Expression<Func<Uyumluluk, bool>> expression);
        public IResult Add(Uyumluluk uyumluluk);
        public IResult Delete(Uyumluluk uyumluluk);
        public IResult Update(Uyumluluk uyumluluk);
    }
}