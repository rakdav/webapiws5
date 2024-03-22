using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapiws5.Models;

public partial class PharmacyContext : DbContext
{
    public PharmacyContext()
    {
    }

    public PharmacyContext(DbContextOptions<PharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WriteOff> WriteOffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WSR;Initial Catalog=Pharmacy;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medication");

            entity.Property(e => e.BestВeforeВate).HasColumnName("bestВeforeВate");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdMedication).HasColumnName("id_medication");

            entity.HasOne(d => d.IdMedicationNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdMedication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Medication");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("Provider");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.ToTable("Shipment");

            entity.Property(e => e.ExpirationDate)
                .HasMaxLength(50)
                .HasColumnName("expirationDate");
            entity.Property(e => e.IdProvider).HasColumnName("idProvider");
            entity.Property(e => e.PartyName)
                .HasMaxLength(50)
                .HasColumnName("Party_name");
            entity.Property(e => e.ShipmentCount).HasColumnName("Shipment_count");
            entity.Property(e => e.ShipmentDate).HasColumnName("Shipment_date");
            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_id");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Provider");

            entity.HasOne(d => d.Medication).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Medication");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Warehouse");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<WriteOff>(entity =>
        {
            entity.ToTable("WriteOff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cause)
                .HasMaxLength(200)
                .HasColumnName("cause");
            entity.Property(e => e.IdShipment).HasColumnName("id_shipment");

            entity.HasOne(d => d.IdShipmentNavigation).WithMany(p => p.WriteOffs)
                .HasForeignKey(d => d.IdShipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WriteOff_Shipment");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
