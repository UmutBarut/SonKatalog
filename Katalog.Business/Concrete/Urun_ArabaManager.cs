using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Concrete;
using Katalog.Entity;

namespace Katalog.Business.Concrete
{
    public class Urun_ArabaManager : IUrun_ArabaService
    {
        private readonly Urun_ArabaDal _urun_ArabaDal;
        public IResult Add(Urun_Araba urun_Araba)
        {
            _urun_ArabaDal.InsertAsync(urun_Araba);
            return new SuccessResult();
        }

        public IResult Delete(Urun_Araba urun_Araba)
        {
            _urun_ArabaDal.Delete(urun_Araba);
            return new SuccessResult();
        }

        public IDataResult<Urun_Araba> GetById(Expression<Func<Urun_Araba, bool>> expression)
        {
            return new SuccessDataResult<Urun_Araba>(_urun_ArabaDal.GetAll(expression).First());
        }

        public IDataResult<List<Urun_Araba>> Urun_ArabaList(Expression<Func<Urun_Araba, bool>> expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Urun_Araba>>(_urun_ArabaDal.GetAll());
            }
            return new SuccessDataResult<List<Urun_Araba>>(_urun_ArabaDal.GetAll(expression));
        }

        public IResult Update(Urun_Araba urun_Araba)
        {
            _urun_ArabaDal.Update(urun_Araba);
            return new SuccessResult();
        }
    }
}