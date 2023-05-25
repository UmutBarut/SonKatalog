using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Katalog.Business.Abstracts
{
    public interface IUrun_ArabaService
    {
        public IDataResult<List<Urun_Araba>> Urun_ArabaList(Expression<Func<Urun_Araba, bool>> expression = null);
        public IDataResult<Urun_Araba> GetById(Expression<Func<Urun_Araba, bool>> expression);
        public IResult Add(Urun_Araba urun_Araba);
        public IResult Delete(Urun_Araba urun_Araba);
        public IResult Update(Urun_Araba urun_Araba);
    }
}