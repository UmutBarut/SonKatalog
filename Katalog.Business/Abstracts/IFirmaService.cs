using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Linq.Expressions;

namespace Katalog.Business.Abstracts
{
    public interface IFirmaService
    {
        public IDataResult<List<Firma>> FirmaList(Expression<Func<Firma, bool>> expression = null);
        public IDataResult<Firma> GetById(Expression<Func<Firma, bool>> expression);
        public IResult Add(Firma firma);
        public IResult Delete(Firma firma);
        public IResult Update(Firma firma);
    }
}