using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;
using si730pc2u202218451.API.Sales.Domain.Model.ValueObjects;
using si730pc2u202218451.API.Shared.Domain.Repositories;

namespace si730pc2u202218451.API.logistics.Domain.Repositories;

public interface IPurchaseOrdersRepository : IBaseRepository<PurchaseOrders>
{
    Task<PurchaseOrders?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId);
}