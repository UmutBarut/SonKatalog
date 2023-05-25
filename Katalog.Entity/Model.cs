using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Model : IEntity
    {
        [Key]
        public long ModelID { get; set; }
        public string ModelAdi { get; set; }
        public long TipID { get; set; }
        public long MarkaID { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
        
    }
}