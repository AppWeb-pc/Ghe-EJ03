namespace si730pc2u202218451.API.logistics.Domain.Model.Commands;

public record CreatePurchaseOrdersCommand(string Customer, int FabricId, string Country, string ResumeUrl, int Quantity);