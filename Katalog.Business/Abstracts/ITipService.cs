using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System.Linq.Expressions;


namespace Katalog.Business.Abstracts
{
    public interface ITipService 
    {
        public IDataResult<List<Tip>> TipList(Expression<Func<Tip, bool>> expression = null);
        public IDataResult<Tip> GetById(Expression<Func<Tip, bool>> expression);
        public IResult Add(Tip tip);
        public IResult Delete(Tip tip);
        public IResult Update(Tip tip);
    }
}