using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Katalog.Business.Abstracts
{
    public interface IKullanilanParcaService
    {
        public IDataResult<List<KullanilanParca>> KullanilanParcaList(Expression<Func<KullanilanParca, bool>> expression = null);
        public IDataResult<KullanilanParca> GetById(Expression<Func<KullanilanParca, bool>> expression);
        public IResult Add(KullanilanParca kullanilanParca);
        public IResult Delete(KullanilanParca kullanilanParca);
        public IResult Update(KullanilanParca kullanilanParca);
    }
}