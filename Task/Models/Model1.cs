using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Task.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<sub_task> sub_task { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.users)
                .WithOptional(e => e.role)
                .HasForeignKey(e => e.role_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<sub_task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<sub_task>()
                .Property(e => e.imagepath)
                .IsUnicode(false);

            modelBuilder.Entity<sub_task>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.sub_task)
                .HasForeignKey(e => e.task_sub)
                .WillCascadeOnDelete();

            modelBuilder.Entity<task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.imagepath)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.imagepath)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.sub)
                .WillCascadeOnDelete();
        }
    }
}
