using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class WarehouseInventoryItem
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int InventoryItemId { get; set; }

        [Display(Name = "Count")]
        public int ItemCount { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }

        public InventoryItem InventoryItem { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
