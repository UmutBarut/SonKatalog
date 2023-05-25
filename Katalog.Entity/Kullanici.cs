using System.ComponentModel.DataAnnotations;
using Katalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Katalog.Entity
{
    public class Kullanici : IdentityUser , IEntity
    {
        
        public string? ImagePath { get; set; }
        public bool IsAdmin { get; set; }
        public string? AdSoyad { get; set; }
        public bool Pasif { get; set; }
    }
}
