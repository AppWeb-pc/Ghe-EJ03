using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;
using si730pc2u202218451.API.logistics.Interfaces.REST.Resources;

namespace si730pc2u202218451.API.logistics.Interfaces.REST.Transform
{
    public static class PurchaseOrdersResourceFromEntityAssembler
    {
        public static PurchaseOrdersResource ToResourceFromEntity(PurchaseOrders entity)
        {
            return new PurchaseOrdersResource(
                entity.Id, 
                entity.Customer,
                entity.FabricId,
                entity.Country,
                entity.ResumeUrl,
                entity.Quantity
            );
        }
    }
}