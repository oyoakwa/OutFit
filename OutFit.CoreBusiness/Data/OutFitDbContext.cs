using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OutFit.CoreBusiness;
using System.Reflection.PortableExecutable;

namespace OutFit.CoreBusiness.Data
{
    public class OutFitDbContext : IdentityDbContext<ApplicationUser>
    {
        public OutFitDbContext()
        {
        }

        public OutFitDbContext(DbContextOptions<OutFitDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product> product { get; set; }
        
        public DbSet<Cart> carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductOrder> productorder { get; set; }
    }
}
