using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;
using System.Linq.Expressions;

namespace Katalog.Business.Concrete
{
    public class FirmaManager : IFirmaService
    {
        private readonly IFirmaDal _firmaDal;

        public FirmaManager(IFirmaDal firmaDal)
        {
            _firmaDal = firmaDal;
        }
        public IResult Add(Firma firma)
        {
            _firmaDal.InsertAsync(firma);
            return new SuccessResult();
        }

        public IResult Delete(Firma firma)
        {
            _firmaDal.Delete(firma);
            return new SuccessResult();
        }

       public IDataResult<List<Firma>> FirmaList(Expression<Func<Firma, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Firma>>(_firmaDal.GetAll());
            }
            return new SuccessDataResult<List<Firma>>(_firmaDal.GetAll(expression));
        }

        public IDataResult<Firma> GetById(Expression<Func<Firma, bool>> expression)
        {
            return new SuccessDataResult<Firma>(_firmaDal.GetAll(expression).First());
        }

        public IResult Update(Firma firma)
        {
            _firmaDal.Update(firma);
            return new SuccessResult();
        }
    }
}