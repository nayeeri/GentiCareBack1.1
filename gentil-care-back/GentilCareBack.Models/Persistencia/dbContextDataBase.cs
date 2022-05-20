using GentilCareBack.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Persistencia
{
    public class dbContextDataBase: DbContext
    {
        /*
        public dbContextDataBase(DbContextOptions<dbContextDataBase> options) : base(options) { 
        }*/

        public dbContextDataBase(DbContextOptions options) : base(options)
        {

        }

        public dbContextDataBase()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=tcp:nayeeri.database.windows.net;Initial Catalog=GentilCare;Persist Security Info=False;User ID=NayeeriUser;Password=Bti180516$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer(@"Server=208.109.38.162;Database=GentilCare;User Id=PruebasQA;Password=Getecsa7.;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
            
        //    /*
        //    modelBuilder.Entity<Users>()
        //        .HasOne(b => b.Auths)
        //        .WithOne(i => i.)
        //        .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
        //    */
        //}

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AparatoRespiratorio> AparatoRespiratorio { get; set; }
        public virtual DbSet<Auths> Auths { get; set; }
        public virtual DbSet<CardioVascular> CardioVascular { get; set; }
        public virtual DbSet<Colaboradors> Colaboradors { get; set; }
        public virtual DbSet<Esfera_Psiquica> Esfera_Psiquica { get; set; }
        public virtual DbSet<Especialidads> Especialidads { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Farmacos> Farmacos { get; set; }
        public virtual DbSet<Interrogatorios> Interrogatorios { get; set; }
        public virtual DbSet<Motivos> Motivos { get; set; }
        public virtual DbSet<PielTegumentos> PielTegumentos { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Recetas> Recetas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sentidos> Sentidos { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Signosvitales> Signosvitales { get; set; }
        public virtual DbSet<SintomasGenerales> SintomasGenerales { get; set; }
        public virtual DbSet<SistemaDigestivo> SistemaDigestivo { get; set; }
        public virtual DbSet<SistemaEmatopoyetico> SistemaEmatopoyetico { get; set; }
        public virtual DbSet<SistemaEndocrino> SistemaEndocrino { get; set; }
        public virtual DbSet<SistemaMusculoEsqueletico> SistemaMusculoEsqueletico { get; set; }
        public virtual DbSet<SistemaNervioso> SistemaNervioso { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Planes> Planes { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }

        public virtual DbSet<Proveedor> Proveedor { get; set; }

        public virtual DbSet<Semana> Semana { get; set; }

        public virtual DbSet<Horas> Horas { get; set; }
    }
}
