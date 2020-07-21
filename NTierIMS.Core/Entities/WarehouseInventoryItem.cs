using System;
using System.Collections.Generic;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class WarehouseInventoryItem
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int InventoryItemId { get; set; }

        public int ItemCount { get; set; }
        public DateTime? LastUpdated { get; set; }

        public InventoryItem InventoryItem { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
