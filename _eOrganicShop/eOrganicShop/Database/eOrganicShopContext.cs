using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public partial class eOrganicShopContext : DbContext
    {

        public eOrganicShopContext(DbContextOptions<eOrganicShopContext> options)
          : base(options)
        {
        }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<KorisnikUloge> KorisnikUloge { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<VrsteProizvoda> VrsteProizvoda { get; set; }
        public virtual DbSet<Proizvodi> Proizvodi { get; set; }
        public virtual DbSet<Rate> Rate{ get; set; }

        public virtual DbSet<Favoriti> Favoriti { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Kupovine> Kupovine { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }

        public virtual DbSet<Transakcije> Transakcije { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Favoriti>()
                .HasKey(k => new { k.KorisnikID, k.ProizvodID });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
