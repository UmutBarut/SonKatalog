using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Core.Entity;

namespace Katalog.Entity
{
    public class OEM : IEntity
    {
        [Key]
        public long FirmaID { get; set; }
        public long UrunID { get; set; }
        public long MarkaID { get; set; }
        public string? OEMno { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}