using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;
using System.Linq.Expressions;

namespace Katalog.Business.Concrete
{
    public class UrunManager : IUrunService
    {

        private readonly IUrunDal _urunDal;


        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;

        }
        public IResult Add(Urun urun)
        {
            _urunDal.InsertAsync(urun);
            return new SuccessResult();
        }

        public IResult Delete(Urun urun)
        {
            _urunDal.Delete(urun);
            return new SuccessResult();
        }

        public IResult Update(Urun urun)
        {
            _urunDal.Update(urun);
            return new SuccessResult();
        }

        public IDataResult<Urun> GetById(Expression<Func<Urun, bool>> expression)
        {
            return new SuccessDataResult<Urun>(_urunDal.GetAll(expression).First());
        }



        public IDataResult<List<Urun>> UrunList(Expression<Func<Urun, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Urun>>(_urunDal.GetAll());
            }
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll(expression));
        }
    }
}