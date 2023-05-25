using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System.Linq.Expressions;

namespace Katalog.Business.Abstracts
{
    public interface IUrunService
    {
        public IDataResult<List<Urun>> UrunList(Expression<Func<Urun, bool>> expression = null);
        public IDataResult<Urun> GetById(Expression<Func<Urun, bool>> expression);
        public IResult Add(Urun urun);
        public IResult Delete(Urun urun);
        public IResult Update(Urun urun);
       
    }
} 
        