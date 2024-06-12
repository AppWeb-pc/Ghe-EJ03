
using si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;

namespace si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    DbSet<PurchaseOrders>PurchaseOrders{ get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
    {
        base.OnConfiguring(modelBuilder);
        // Enable Audit Fields Interceptors
        modelBuilder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // PurchaseOrders Context
        modelBuilder.Entity<PurchaseOrders>().HasKey(po => po.Id);
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.Customer).IsRequired();
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.FabricId).IsRequired();
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.Country).IsRequired();
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.ResumeUrl).IsRequired();
        modelBuilder.Entity<PurchaseOrders>().Property(po => po.Quantity).IsRequired();
        
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}
