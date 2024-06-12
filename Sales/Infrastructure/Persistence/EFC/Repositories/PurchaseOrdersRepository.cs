using Microsoft.EntityFrameworkCore;
using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;
using si730pc2u202218451.API.logistics.Domain.Repositories;
using si730pc2u202218451.API.Sales.Domain.Model.ValueObjects;
using si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u202218451.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u202218451.API.logistics.Infrastructure.Persistence.EFC.Repositories
{
    public class PurchaseOrdersRepository(AppDbContext context) : BaseRepository<PurchaseOrders>(context), IPurchaseOrdersRepository
    {
     

        public async Task<PurchaseOrders?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId)
        {
            return await context.Set<PurchaseOrders>()
                .FirstOrDefaultAsync(po => po.Customer == customer && po.FabricId == (int)fabricId);
        }
    }
}