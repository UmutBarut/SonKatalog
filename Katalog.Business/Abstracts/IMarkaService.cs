using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System.Linq.Expressions;


namespace Katalog.Business.Abstracts
{
    public interface IMarkaService
    {
        public IDataResult<List<Marka>> MarkaList(Expression<Func<Marka, bool>> expression = null);
        public IDataResult<Marka> GetById(Expression<Func<Marka, bool>> expression);
        public IResult Add(Marka marka);
        public IResult Delete(Marka marka);
        public IResult Update(Marka marka);
    }
}