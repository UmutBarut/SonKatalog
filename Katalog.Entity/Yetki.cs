using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Core.Entity;

namespace Katalog.Entity
{
    public class Yetki :IEntity
    {
        public long YetkiID { get; set; }
        public long UserID { get; set; }
        public long RolID { get; set; }
    }
}