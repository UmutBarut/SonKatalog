using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Core.Entity;

namespace Katalog.Entity
{
    public class Firma : IEntity
    {
        [Key]
        public long FirmaID { get; set; }
        public string FirmaAdi { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}