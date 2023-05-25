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
    public class ReferansManager : IReferansService
    {
        private readonly IReferansDal _referansDal;

        public ReferansManager(IReferansDal referansDal)
        {
            _referansDal = referansDal;
        }
        public IResult Add(Referans referans)
        {
            _referansDal.InsertAsync(referans);
            return new SuccessResult();
        }

        public IResult Delete(Referans referans)
        {
            _referansDal.Delete(referans);
            return new SuccessResult();
        }

        public IDataResult<Referans> GetById(Expression<Func<Referans, bool>> expression)
        {
            return new SuccessDataResult<Referans>(_referansDal.GetAll(expression).First());
        }

        public IDataResult<List<Referans>> ReferansList(Expression<Func<Referans, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Referans>>(_referansDal.GetAll());
            }
            return new SuccessDataResult<List<Referans>>(_referansDal.GetAll(expression));
        }

        public IResult Update(Referans referans)
        {
            _referansDal.Update(referans);
            return new SuccessResult();
        }
    }
}