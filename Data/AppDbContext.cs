using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Model;

namespace OnlineStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductAttribute> productAttributes { get; set; }
        public DbSet<ProductAttributeType> productAttributeTypes { get; set; }
    }
}