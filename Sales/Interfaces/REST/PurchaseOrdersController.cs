using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u202218451.API.logistics.Domain.Services;
using si730pc2u202218451.API.logistics.Interfaces.REST.Resources;
using si730pc2u202218451.API.logistics.Interfaces.REST.Transform;

namespace si730pc2u202218451.API.logistics.Interfaces.REST
{
    /// <summary>
    /// This controller handles the HTTP requests related to Purchase Orders.
    /// </summary>
    /// <remarks>
    /// Author: Jherson Astuyauri
    /// </remarks>
    [ApiController]
    [Route("api/v1/purchase-orders")]
    [Produces(MediaTypeNames.Application.Json)]
    
    /// <summary>
    /// Constructor for the PurchaseOrdersController.
    /// </summary>
    /// <param name="purchaseOrdersCommandService">The service to handle commands related to Purchase Orders.</param>
    public class PurchaseOrdersController(IPurchaseOrdersCommandService purchaseOrdersCommandService) : ControllerBase
    {
        /// <summary>
        /// This method handles the creation of a new Purchase Order.
        /// </summary>
        /// <param name="resource">The resource representing the Purchase Order to be created.</param>
        /// <returns>An IActionResult representing the result of the creation operation.</returns> 
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(CreatePurchaseOrdersResource resource)
        {
            var createPurchaseOrderCommand = CreatePurchaseOrdersCommandFromResourceAssembler.ToCommandFromResource(resource);
            var purchaseOrder = await purchaseOrdersCommandService.Handle(createPurchaseOrderCommand);
            if (purchaseOrder is null) return BadRequest();
            var purchaseOrdersResource = PurchaseOrdersResourceFromEntityAssembler.ToResourceFromEntity(purchaseOrder);
            return new CreatedResult(string.Empty, purchaseOrdersResource);
        }

    }
}