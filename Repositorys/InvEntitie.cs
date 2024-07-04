using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PROJECT.Repositorys.Models;

namespace PROJECT.Repositorys;

public partial class InvEntitie : DbContext
{
    public InvEntitie()
    {
    }

    public InvEntitie(DbContextOptions<InvEntitie> options)
        : base(options)
    {
    }

    public virtual DbSet<Attr> Attrs { get; set; }

    public virtual DbSet<ImageAndFp> ImageAndFps { get; set; }

    public virtual DbSet<ImageFace> ImageFaces { get; set; }

    public virtual DbSet<ImageFp> ImageFps { get; set; }

    public virtual DbSet<Invest> Invests { get; set; }

    public virtual DbSet<Invperson> Invpersons { get; set; }

    public virtual DbSet<Invworld> Invworlds { get; set; }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<Village> Villages { get; set; }

    public virtual DbSet<Worldkey> Worldkeys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=simpleinvest;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attr>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Attr__A25C5AA65A9AB756");

            entity.Property(e => e.Code).ValueGeneratedNever();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<ImageAndFp>(entity =>
        {
            entity.HasKey(e => new { e.Serial, e.Serpers }).HasName("PK__ImageAnd__C87A60D5EB456BFB");
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<ImageFace>(entity =>
        {
            entity.HasKey(e => new { e.Serial, e.Serpers }).HasName("PK__ImageFac__52B352DEA50AAC00");
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<ImageFp>(entity =>
        {
            entity.HasKey(e => new { e.Serial, e.Serpers }).HasName("PK__ImageFP__52B352DE4985B065");
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Invest>(entity =>
        {
            entity.HasKey(e => e.Serial).HasName("PK__INVEST__1CE6D4E6552DE31F");

            entity.Property(e => e.Serial).ValueGeneratedNever();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Invperson>(entity =>
        {
            entity.HasKey(e => new { e.Serial, e.Serpers }).HasName("PK__invperso__52B352DE252DBCF7");
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Invworld>(entity =>
        {
            entity.HasKey(e => new { e.Serial, e.Id }).HasName("PK__Invworld__7FC79A24BEAF807F");
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__nations__AA1D4378C5A4EC64");

            entity.Property(e => e.Code).ValueGeneratedNever();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vid).HasName("PK__vehicles__DDB00C7D519F8488");

            entity.Property(e => e.Vid).ValueGeneratedNever();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Village__AA1D4378EAAEF529");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Label).IsFixedLength();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        modelBuilder.Entity<Worldkey>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__worldkey__AA1D437848CAFBFA");

            entity.Property(e => e.Code).ValueGeneratedNever();
            // Configure RowVersion as a concurrency token
            entity.Property(e => e.RowVersion)
                  .IsRowVersion()
                  .IsConcurrencyToken();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
