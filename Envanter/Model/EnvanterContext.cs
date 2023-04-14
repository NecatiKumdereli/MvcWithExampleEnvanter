using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Envanter.Model;

public partial class EnvanterContext : DbContext
{
    public EnvanterContext()
    {
    }

    public EnvanterContext(DbContextOptions<EnvanterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonWare> PersonWares { get; set; }

    public virtual DbSet<Ware> Wares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\Envanter.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.HasIndex(e => e.Id, "IX_Person_Id").IsUnique();
        });

        modelBuilder.Entity<PersonWare>(entity =>
        {
            entity.ToTable("PersonWare");

            entity.HasIndex(e => e.Id, "IX_PersonWare_Id").IsUnique();

            entity.HasOne(d => d.Person).WithMany(p => p.PersonWares)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ware).WithMany(p => p.PersonWares)
                .HasForeignKey(d => d.WareId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ware>(entity =>
        {
            entity.ToTable("Ware");

            entity.HasIndex(e => e.Id, "IX_Ware_Id").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
