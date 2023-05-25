using Katalog.Core.Utilities.Results;
using Katalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Katalog.Business.Abstracts
{
    public interface IOEMService
    {
        public IDataResult<List<OEM>> OEMList(Expression<Func<OEM, bool>> expression = null);
        public IDataResult<OEM> GetById(Expression<Func<OEM, bool>> expression);
        public IResult Add(OEM oem);
        public IResult Delete(OEM oem);
        public IResult Update(OEM oem);
    }
}