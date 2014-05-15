using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Model;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Order>()
                .ToTable("Order")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithRequired(x => x.Order)
                .Map(x => x.MapKey("OrderId"));

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<Product>()
            //    .HasOptional(x => x.Category);
            
            //modelBuilder.Entity<Category>()
            //    .ToTable("Category")
            //    .HasKey(x => x.Id)
            //    .Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}