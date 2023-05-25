using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Referans : IEntity
    {
        [Key]
        public long RefID { get; set; }
        public string RefNo { get; set; }
        public long FirmaID { get; set; }
        public long UrunID { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}