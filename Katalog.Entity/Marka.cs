using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katalog.Entity
{
    public class Marka : IEntity
    {
        [Key]
        public long MarkaID { get; set; }
        public string? MarkaAdi { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
        public string? ImagePath { get; set; }
        
    }
}