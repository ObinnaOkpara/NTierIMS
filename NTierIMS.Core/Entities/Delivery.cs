using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        [Display(Name = "Inventory Item")]
        public int InventoryItemId { get; set; }
        [Display(Name = "Number of Item Delivered")]
        public int NumberOfItemDelivered { get; set; }
        [Display(Name = "Delivery Date")]
        public DateTime? DeliveryDate { get; set; } = DateTime.Now;
        [Display(Name = "Recorded By")]
        public string EmployeeId { get; set; }

        public Warehouse Warehouse { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public Employee Employee { get; set; }

    }
}
