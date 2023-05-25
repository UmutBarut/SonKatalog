using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Results;
using Katalog.Dataaccess.Abstracts;
using Katalog.Entity;



namespace Katalog.Business.Concrete
{
    public class KullanilanParcaManager : IKullanilanParcaService
    {
        private readonly IKullanilanParcaDal _kullanilanparcaDal;
        public KullanilanParcaManager(IKullanilanParcaDal kullanilanparcaDal)
        {
            _kullanilanparcaDal = kullanilanparcaDal;
        }

        public IResult Add(KullanilanParca kullanilanParca)
        {
            _kullanilanparcaDal.InsertAsync(kullanilanParca);
            return new SuccessResult();
        }

        public IResult Delete(KullanilanParca kullanilanParca)
        {
            _kullanilanparcaDal.Delete(kullanilanParca);
            return new SuccessResult();
        }

        public IDataResult<KullanilanParca> GetById(Expression<Func<KullanilanParca, bool>> expression)
        {
            return new SuccessDataResult<KullanilanParca>(_kullanilanparcaDal.GetAll(expression).First());
        }

         public IDataResult<List<KullanilanParca>> KullanilanParcaList(Expression<Func<KullanilanParca, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<KullanilanParca>>(_kullanilanparcaDal.GetAll());
            }
            return new SuccessDataResult<List<KullanilanParca>>(_kullanilanparcaDal.GetAll(expression));
        }

        public IResult Update(KullanilanParca kullanilanParca)
        {
            _kullanilanparcaDal.Update(kullanilanParca);
            return new SuccessResult();
        }
    }
}