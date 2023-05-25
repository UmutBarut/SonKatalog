using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katalog.Core.Entity;

namespace Katalog.Entity
{
    public class Uyumluluk : IEntity
    {
        [Key]
        public long UyumID { get; set; }
        public long UrunID { get; set; }
        public string Uyum { get; set; }
        public long Siralama { get; set; }
        public long ModelID { get; set; }

    }
}