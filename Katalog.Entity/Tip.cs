
using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Tip : IEntity
    {
        [Key]
        public long TipID { get; set; }
        public string TipAdi { get; set; }
        public long MarkaID { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}