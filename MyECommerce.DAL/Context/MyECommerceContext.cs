using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyECommerce.DAL.Seed;
using MyECommerce.Entity.Entity;


namespace MyECommerce.DAL.Context
{
    public class MyECommerceContext :IdentityDbContext<AppUser>
    {
        public MyECommerceContext(DbContextOptions<MyECommerceContext>options):base(options) 
        {
        
        }
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(ProductSeed.products);

            builder.Entity<Category>().HasData(CategorySeed.categories);

            base.OnModelCreating(builder);  
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    { 
        //        optionsBuilder.UseSqlServer("MyConnection");
        //    }
        //}
    }
}
