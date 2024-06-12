using System;
using System.ComponentModel.DataAnnotations;
using si730pc2u202218451.API.logistics.Domain.Model.Commands;

namespace si730pc2u202218451.API.logistics.Domain.Model.Aggregates
{
    /// <summary>
    /// This class represents a Purchase Order in the system.
    /// </summary>
    /// <remarks>
    /// Author: Jherson Astuyauri
    /// </remarks>
    public partial class PurchaseOrders
    {
        /// <summary>
        /// The unique identifier for the Purchase Order.
        /// </summary>
        [Key] public int Id { get; private set; }

        /// <summary>
        /// The customer associated with the Purchase Order.
        /// </summary>
        [Required]
        public string Customer { get; private set; }

        /// <summary>
        /// The FabricId associated with the Purchase Order.
        /// </summary>
        [Required]
        public int FabricId { get; private set; }

        /// <summary>
        /// The country associated with the Purchase Order.
        /// </summary>
        [Required]
        public string Country { get; private set; }

        /// <summary>
        /// The ResumeUrl associated with the Purchase Order.
        /// </summary>
        [Required]
        public string ResumeUrl { get; private set; }

        /// <summary>
        /// The quantity associated with the Purchase Order.
        /// </summary>
        [Required]
        public int Quantity { get; private set; }
        
        /// <summary>
        /// Constructor for creating a new Purchase Order with given parameters.
        /// </summary>
        public PurchaseOrders(string customer, int fabricId, string country, string resumeUrl, int quantity)
        {
            Customer = customer;
            FabricId = fabricId;
            Country = country;
            ResumeUrl = resumeUrl;
            Quantity = quantity;
        }
        
        /// <summary>
        /// Constructor for creating a new Purchase Order with a given command.
        /// </summary>
        public PurchaseOrders(CreatePurchaseOrdersCommand command)
        {
            Customer = command.Customer;
            FabricId = command.FabricId;
            Country = command.Country;
            ResumeUrl = command.ResumeUrl;
            Quantity = command.Quantity;
        }
    }
}