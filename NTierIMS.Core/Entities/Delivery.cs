using System;
using System.Collections.Generic;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int InventoryItemId { get; set; }
        public int NumberOfItemDelivered { get; set; }
        public DateTime? DeliveryDate { get; set; } = DateTime.Now;
        public string EmployeeId { get; set; }

        public Warehouse Warehouse { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public Employee Employee { get; set; }

    }
}
