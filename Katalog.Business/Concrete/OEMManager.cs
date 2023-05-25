using System.Linq.Expressions;
using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;
namespace Katalog.Business.Concrete
{
    public class OEMManager : IOEMService
    {
        private readonly IOEMDal _oemDal;

        public OEMManager(IOEMDal oemDal)
        {
            _oemDal = oemDal;
        }
        public IResult Add(OEM oem)
        {
           _oemDal.InsertAsync(oem);
           return new SuccessResult();
        }

        public IResult Delete(OEM oem)
        {
            _oemDal.Delete(oem);
           return new SuccessResult();
        }

        public IDataResult<OEM> GetById(Expression<Func<OEM, bool>> expression)
        {
            return new SuccessDataResult<OEM>(_oemDal.GetAll(expression).First());
        }

        public IDataResult<List<OEM>> OEMList(Expression<Func<OEM, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<OEM>>(_oemDal.GetAll());
            }
            return new SuccessDataResult<List<OEM>>(_oemDal.GetAll(expression));
        }

        public IResult Update(OEM oem)
        {
            _oemDal.Update(oem);
           return new SuccessResult();
        }
    }
}