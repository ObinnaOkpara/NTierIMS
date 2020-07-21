using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Removal
    {
        public int Id { get; set; }
        [Display(Name = "Warehouse")]
        public int WarehouseId { get; set; }
        [Display(Name = "Inventory Item")]
        public int InventoryItemId { get; set; }
        [Display(Name = "Number of Item Removed")]
        public int NumberOfItemRemoved { get; set; }
        [Display(Name = "Removal Date")]
        public DateTime? RemovalDate { get; set; } = DateTime.Now;
        [Display(Name = "Recorded by")]
        public string EmployeeId { get; set; }
        [StringLength(350, ErrorMessage = "Maximum Lenght is 350 characters")]
        public string Reason { get; set; }

        public Warehouse Warehouse { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public Employee Employee { get; set; }
    }
}
