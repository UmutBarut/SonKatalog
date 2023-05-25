using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;
using System.Linq.Expressions;


namespace Katalog.Business.Concrete
{
    public class TipManager : ITipService
    {
        private readonly ITipDal _tipDal;
        

        public TipManager(ITipDal tipDal)
        {
            _tipDal = tipDal;
            
        }

        public IResult Add(Tip tip)
        {
           _tipDal.InsertAsync(tip);
            return new SuccessResult();
        }

        public IResult Delete(Tip tip)
        {
            _tipDal.Delete(tip);
            return new SuccessResult();
        }

        public IDataResult<Tip> GetById(Expression<Func<Tip, bool>> expression)
        {
            return new SuccessDataResult<Tip>(_tipDal.GetAll(expression).First());
        }

        public IDataResult<List<Tip>> TipList(Expression<Func<Tip, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Tip>>(_tipDal.GetAll());
            }
            return new SuccessDataResult<List<Tip>>(_tipDal.GetAll(expression));
        }

        public IResult Update(Tip tip)
        {
            _tipDal.Update(tip);
            return new SuccessResult();
        }
    }
}