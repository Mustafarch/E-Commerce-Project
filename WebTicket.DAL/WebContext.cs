using Microsoft.EntityFrameworkCore;
using WebTicket.Entities;

namespace WebTicket.DAL
{
    public class WebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MUSTAFA\SQLEXPRESS;Database=Mustafa-E-Ticaret;Trusted_Connection=True;");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<BlogReview> BlogReviews { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        
        public DbSet<Kullanicilar> Kullanici { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Satilanlar> Satilanlar { get; set; }
    }
}
