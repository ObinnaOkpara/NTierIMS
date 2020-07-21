using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Removal
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int InventoryItemId { get; set; }
        public int NumberOfItemRemoved { get; set; }
        public DateTime? RemovalDate { get; set; } = DateTime.Now;
        public string EmployeeId { get; set; }
        [StringLength(350, ErrorMessage = "Maximum Lenght is 350 characters")]
        public string Reason { get; set; }

        public Warehouse Warehouse { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public Employee Employee { get; set; }
    }
}
