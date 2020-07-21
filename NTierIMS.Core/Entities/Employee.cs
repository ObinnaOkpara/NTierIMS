using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Employee : IdentityUser
    {
        [StringLength(200, ErrorMessage = "Maximum Lenght is 200 characters")]
        [Required(ErrorMessage = "This Field is required")]
        public string FullName { get; set; }

        public Delivery DeliveriesRecorded { get; set; }
        public Removal RemovalsRecorded { get; set; }
        public Warehouse WarehouseCreated { get; set; }
        public InventoryItem InventoryItemCreated { get; set; }
    }
}
