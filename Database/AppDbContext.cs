using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using System;

namespace Reservation.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<QRCodeToken> QRCodeTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Visitor)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VisitorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Staff)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QRCodeToken>()
                .HasIndex(q => q.Uuid)
                .IsUnique();

            // Seed Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Alice Accueil", Role = "Agent d'accueil", Email = "alice@entreprise.com" },
                new Staff { Id = 2, Name = "Bob Collaborateur", Role = "Personnel", Email = "bob@entreprise.com" },
                new Staff { Id = 3, Name = "Charlie IT", Role = "Administrateur", Email = "charlie@entreprise.com" }
            );

            // Seed Visitors (5 visiteurs)
            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, FirstName = "Alexandre", LastName = "Lejunior", Email = "alexandre@example.com", Phone = "0123456789", Status = "Enregistré", VisitReason = "Rendez-vous", ContactStaffId = 1 },
                new Visitor { Id = 2, FirstName = "Élodie", LastName = "Martin", Email = "elodie@example.com", Phone = "0987654321", Status = "Enregistré", VisitReason = "Coworking", ContactStaffId = 2 },
                new Visitor { Id = 3, FirstName = "Paul", LastName = "Dupont", Email = "paul@example.com", Phone = "0147852369", Status = "Enregistré", VisitReason = "Coworking", ContactStaffId = 1 },
                new Visitor { Id = 4, FirstName = "Sophie", LastName = "Durand", Email = "sophie@example.com", Phone = "0172638495", Status = "Enregistré", VisitReason = "Rendez-vous", ContactStaffId = 3 },
                new Visitor { Id = 5, FirstName = "Julien", LastName = "Moreau", Email = "julien@example.com", Phone = "0192837465", Status = "Enregistré", VisitReason = "Rendez-vous", ContactStaffId = 2 }
            );

            // Seed Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, Date = new DateTime(2025, 7, 10, 9, 0, 0), StaffId = 1, VisitorId = 1 },
                new Appointment { Id = 2, Date = new DateTime(2025, 7, 10, 10, 30, 0), StaffId = 2, VisitorId = 2 },
                new Appointment { Id = 3, Date = new DateTime(2025, 7, 11, 14, 0, 0), StaffId = 1, VisitorId = 3 },
                new Appointment { Id = 4, Date = new DateTime(2025, 7, 12, 16, 0, 0), StaffId = 3, VisitorId = 4 },
                new Appointment { Id = 5, Date = new DateTime(2025, 7, 13, 11, 0, 0), StaffId = 2, VisitorId = 5 }
            );

            // Seed QRCodeTokens with static values
            modelBuilder.Entity<QRCodeToken>().HasData(
                new QRCodeToken { Id = 1, Uuid = "11111111-1111-1111-1111-111111111111", IsUsed = false, Expiration = new DateTime(2025, 7, 10, 12, 0, 0) },
                new QRCodeToken { Id = 2, Uuid = "22222222-2222-2222-2222-222222222222", IsUsed = false, Expiration = new DateTime(2025, 7, 10, 13, 0, 0) },
                new QRCodeToken { Id = 3, Uuid = "33333333-3333-3333-3333-333333333333", IsUsed = true, Expiration = new DateTime(2025, 7, 10, 8, 0, 0) },
                new QRCodeToken { Id = 4, Uuid = "44444444-4444-4444-4444-444444444444", IsUsed = false, Expiration = new DateTime(2025, 7, 10, 10, 0, 0) },
                new QRCodeToken { Id = 5, Uuid = "55555555-5555-5555-5555-555555555555", IsUsed = false, Expiration = new DateTime(2025, 7, 10, 11, 0, 0) }
            );
        }
    }
}
