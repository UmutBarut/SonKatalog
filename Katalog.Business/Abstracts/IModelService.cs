using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System.Linq.Expressions;


namespace Katalog.Business.Abstracts
{
    public interface IModelService
    {
        public IDataResult<List<Model>> ModelList(Expression<Func<Model, bool>> expression = null);
        public IDataResult<Model> GetById(Expression<Func<Model, bool>> expression);
        public IResult Add(Model model);
        public IResult Delete(Model model);
        public IResult Update(Model model);
    }
}