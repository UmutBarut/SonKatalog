using Katalog.Entity;
using Microsoft.EntityFrameworkCore;
using Katalog.Entity.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Katalog.Dataaccess.Concrete.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Tip> Tipler { get; set; }
        public DbSet<Model> Modeller { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<KullanilanParca> KullanilanParcalar { get; set; }
        public DbSet<OEM> OEMler { get; set; }
        public DbSet<Referans> Referanslar { get; set; }
        public DbSet<Uyumluluk> Uyumluluklar { get; set; }
        public DbSet<Urun_Araba> Urun_Araba { get; set; }
        public DbSet<KatalogListe> KatalogListesi { get; set; }
        public DbSet<detaytablo> detaytablosu { get; set; }
        public DbSet<searchresult> searchresults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 30));
            // optionsBuilder.UseMySql(@"Server=fet.com.tr;Port=3306;Database=fetcomtr_katalog2;Uid=fetcomtr_katalog2;Pwd=UmutPro123!;", version);
            optionsBuilder.UseMySql(@"Server=localhost;Port=3306;Database=katalogg;Uid=root;Pwd=Umut2003;", version);
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<searchresult>().HasNoKey().ToView("searchresult");
            modelBuilder.Entity<KatalogListe>().HasNoKey().ToView("KatalogListe");
            modelBuilder.Entity<detaytablo>().HasNoKey().ToView("detaytablo");

            base.OnModelCreating(modelBuilder);
        }
    }
}