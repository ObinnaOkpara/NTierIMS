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

        public List<Delivery> DeliveriesRecorded { get; set; } = new List<Delivery>();
        public List<Removal> RemovalsRecorded { get; set; } = new List<Removal>();
        public List<Warehouse> WarehouseCreated { get; set; } = new List<Warehouse>();
        public List<InventoryItem> InventoryItemCreated { get; set; } = new List<InventoryItem>();
    }
}
