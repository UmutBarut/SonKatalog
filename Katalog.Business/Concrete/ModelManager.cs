using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;
using System.Linq.Expressions;


namespace Katalog.Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public IResult Add(Model model)
        {
            _modelDal.InsertAsync(model);
            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<Model> GetById(Expression<Func<Model, bool>> expression)
        {
            return new SuccessDataResult<Model>(_modelDal.GetAll(expression).First());
        }

        public IDataResult<List<Model>> ModelList(Expression<Func<Model, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
            }
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(expression));
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}