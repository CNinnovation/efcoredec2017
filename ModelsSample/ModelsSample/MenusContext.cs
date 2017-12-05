using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static ModelsSample.MenuDefinitions;

namespace ModelsSample
{
    public class MenuDefinitions
    {
        public const string TitleField = "_title";
        public const string Subtitle = nameof(Subtitle);
    }

    public class MenusContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=MenusSample3;trusted_connection=true";
        public DbSet<Menu> Menus { get; set; }  // convention table
        public DbSet<MenuCard> MenuCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("kantine");
            // modelBuilder.Entity<Menu>().ToTable("OtherMenus");
            //modelBuilder.Entity<Menu>().Property(m => m.Title).HasField(TitleField);
            //modelBuilder.Entity<Menu>().Property(m => m.Subtitle).HasMaxLength(60).IsRequired(false);

            modelBuilder.ApplyConfiguration(new MenuConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
