namespace si730pc2u202218451.API.logistics.Interfaces.REST.Resources;

public record CreatePurchaseOrdersResource(string Customer, int FabricId, string Country, string ResumeUrl, int Quantity);