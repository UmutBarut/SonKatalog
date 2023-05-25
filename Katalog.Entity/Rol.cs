using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Rol : IEntity
    {
        [Key]
        public long RolID { get; set; }
        public string RolAdi { get; set; }
        public bool Pasif { get; set; }
    }
}
