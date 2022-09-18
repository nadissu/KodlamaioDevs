using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistance.Contexts
{
    public class MsSqlDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }


        public MsSqlDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<LanguageTechnology>(a =>
            {
                a.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);


            });
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            LanguageTechnology[] languageTechnologyEntitySeeds = { new(1, 1, "ASP.NET"), new(2, 1, ".NET CORE"), new(3, 2, "SPRİNG"), new(4, 2, "JSP") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologyEntitySeeds);

        }
    }

}
