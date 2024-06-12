using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;
using si730pc2u202218451.API.logistics.Domain.Model.Commands;

namespace si730pc2u202218451.API.logistics.Domain.Services;

public interface IPurchaseOrdersCommandService
{
    
    Task<PurchaseOrders?> Handle(CreatePurchaseOrdersCommand command);
    
    
}