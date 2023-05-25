using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Katalog.Business.Abstracts
{
    public interface IReferansService
    {
        public IDataResult<List<Referans>> ReferansList(Expression<Func<Referans, bool>> expression = null);
        public IDataResult<Referans> GetById(Expression<Func<Referans, bool>> expression);
        public IResult Add(Referans referans);
        public IResult Delete(Referans referans);
        public IResult Update(Referans referans);
    }
}