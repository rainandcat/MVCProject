using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
    }
}
