using si730pc2u202218451.API.logistics.Domain.Model.Aggregates;
using si730pc2u202218451.API.logistics.Domain.Model.Commands;
using si730pc2u202218451.API.logistics.Domain.Repositories;
using si730pc2u202218451.API.logistics.Domain.Services;
using si730pc2u202218451.API.Sales.Domain.Model.ValueObjects;
using si730pc2u202218451.API.Shared.Domain.Repositories;

/// <summary>
/// This class handles the command services related to Purchase Orders.
/// </summary>
/// <remarks>
/// Author: Jherson Astuyauri
/// </remarks>
///
namespace si730pc2u202218451.API.Sales.Application.Internal.CommandServices
{

    /// /// <summary>
    /// Constructor for the PurchaseOrdersCommandService.
    /// </summary>
    /// <param name="purchaseOrdersRepository">The repository to handle Purchase Orders data.</param>
    /// <param name="unitOfWork">The unit of work to handle database transactions.</param>
    public class  PurchaseOrdersCommandService (IPurchaseOrdersRepository purchaseOrdersRepository, IUnitOfWork unitOfWork) : IPurchaseOrdersCommandService
    { 

        /// <summary>
        /// This method handles the command to create a new Purchase Order.
        /// </summary>
        /// <param name="command">The command representing the Purchase Order to be created.</param>
        /// <returns>A Task that represents the asynchronous operation. The task result contains the Purchase Order created, or null if the operation failed.</returns>
    public async Task<PurchaseOrders?> Handle(CreatePurchaseOrdersCommand command)
        {
            
            try
            {
                // Check if a purchase order with the same Customer and FabricId already exists
                var existingPurchaseOrder = await purchaseOrdersRepository.FindByCustomerAndFabricIdAsync(command.Customer, (EFabric)command.FabricId);
                if (existingPurchaseOrder != null)
                {
                    throw new ArgumentException("A purchase order with the same Customer and FabricId already exists.");
                }

                // Check if FabricId is valid
                if (!Enum.IsDefined(typeof(EFabric), command.FabricId))
                {
                    throw new ArgumentException("FabricId must be a valid value.");
                }

                var purchaseOrder = new PurchaseOrders(command);

                await purchaseOrdersRepository.AddAsync(purchaseOrder);
                await unitOfWork.CompleteAsync();

                return purchaseOrder;
            }
            catch (ArgumentException ex)
            {
                // Catch the exception and rethrow it with only the message
                throw new Exception(ex.Message);
            }
        }
    }
}