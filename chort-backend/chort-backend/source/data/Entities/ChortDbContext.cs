using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chort_backend.source.data.entities
{
    public partial class ChortDbContext : DbContext
    {
        public ChortDbContext()
        {
        }

        public ChortDbContext(DbContextOptions<ChortDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChoreEvents> ChoreEvents { get; set; } = null!;
        public virtual DbSet<FrequencyScheduledChores> FrequencyScheduledChores { get; set; } = null!;
        public virtual DbSet<HouseholdMembers> HouseholdMembers { get; set; } = null!;
        public virtual DbSet<Households> Households { get; set; } = null!;
        public virtual DbSet<ScheduledChores> ScheduledChores { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=ruby.db.elephantsql.com;Port=5432;Database=ubbajsdn;User Id=ubbajsdn;Password=jMCzN05hmtIB7HhVzH5DGakY1H5ql1mZ;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<ChoreEvents>(entity =>
            {
                entity.ToTable("chore_events");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.CompletedDatetime).HasColumnName("completed_datetime");

                entity.Property(e => e.ScheduledChoreId)
                    .HasColumnType("character varying")
                    .HasColumnName("scheduled_chore_id");

                entity.HasOne(d => d.ScheduledChore)
                    .WithMany(p => p.ChoreEvents)
                    .HasForeignKey(d => d.ScheduledChoreId)
                    .HasConstraintName("chore_events_scheduled_chore_id_fkey");
            });

            modelBuilder.Entity<FrequencyScheduledChores>(entity =>
            {
                entity.ToTable("frequency__scheduled_chores");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");
            });

            modelBuilder.Entity<HouseholdMembers>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("household_members");

                entity.Property(e => e.HouseholdId)
                    .HasColumnType("character varying")
                    .HasColumnName("household_id");

                entity.Property(e => e.MemberId)
                    .HasColumnType("character varying")
                    .HasColumnName("member_id");

                entity.HasOne(d => d.Household)
                    .WithMany()
                    .HasForeignKey(d => d.HouseholdId)
                    .HasConstraintName("household_members_household_id_fkey");

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("household_members_member_id_fkey");
            });

            modelBuilder.Entity<Households>(entity =>
            {
                entity.ToTable("households");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("character varying")
                    .HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Households)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("households_owner_id_fkey");
            });

            modelBuilder.Entity<ScheduledChores>(entity =>
            {
                entity.ToTable("scheduled_chores");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.AssigneeId)
                    .HasColumnType("character varying")
                    .HasColumnName("assignee_id");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.Frequency).HasColumnName("frequency");

                entity.Property(e => e.HouseholdId)
                    .HasColumnType("character varying")
                    .HasColumnName("household_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.ScheduledChores)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("scheduled_chores_assignee_id_fkey");

                entity.HasOne(d => d.FrequencyNavigation)
                    .WithMany(p => p.ScheduledChores)
                    .HasForeignKey(d => d.Frequency)
                    .HasConstraintName("scheduled_chores_frequency_fkey");

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.ScheduledChores)
                    .HasForeignKey(d => d.HouseholdId)
                    .HasConstraintName("scheduled_chores_household_id_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
