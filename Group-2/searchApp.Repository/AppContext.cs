using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using searchApp.Domain;

namespace searchApp.Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Search>().HasKey(p => p.Id);
            modelBuilder.Entity<Search>().Property(p => p.Answer).IsRequired();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Search>().Property(p => p.Answer)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}