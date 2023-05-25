using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Entity;
using Katalog.Core.Dataaccess;


namespace Katalog.Dataaccess.Abstracts
{
    public interface IFirmaDal : IEntityRepository<Firma>
    {
        
    }
}