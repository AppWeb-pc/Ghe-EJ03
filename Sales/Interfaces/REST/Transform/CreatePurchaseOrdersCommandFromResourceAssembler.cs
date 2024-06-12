using si730pc2u202218451.API.logistics.Domain.Model.Commands;
using si730pc2u202218451.API.logistics.Interfaces.REST.Resources;

namespace si730pc2u202218451.API.logistics.Interfaces.REST.Transform
{
    public static class CreatePurchaseOrdersCommandFromResourceAssembler
    {
        public static CreatePurchaseOrdersCommand ToCommandFromResource(CreatePurchaseOrdersResource resource)
        {
            return new CreatePurchaseOrdersCommand(
                resource.Customer, resource.FabricId, resource.Country, resource.ResumeUrl, resource.Quantity);
        }
    }
}