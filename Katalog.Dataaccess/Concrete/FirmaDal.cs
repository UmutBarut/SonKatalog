using Katalog.Core.Dataaccess.EntityFramework;
using Katalog.Dataaccess.Abstracts;
using Katalog.Dataaccess.Concrete.Contexts;
using Katalog.Entity;
using Katalog.Dataaccess.Abstracts;

namespace Katalog.Dataaccess.Concrete
{
    public class FirmaDal : EfEntityRepositoryBase<Firma, ApplicationDbContext>, IFirmaDal
    {
        
    }
}