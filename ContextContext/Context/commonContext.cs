using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.LanguageAgg;

namespace CommonContext.Context
{
    public class CommonContext : DbContext
    {
        public CommonContext(DbContextOptions<CommonContext> options) : base(options) { }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.ApplyConfiguration(new LanguageMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
