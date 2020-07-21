using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Maximum Lenght is 200 characters")]
        [Required(ErrorMessage = "This Field is required")]
        public string Name { get; set; }
        [StringLength(350, ErrorMessage = "Maximum Lenght is 350 characters")]
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Maximum Lenght is 100 characters")]
        [Required(ErrorMessage = "This Field is required")]
        [Display(Name = "Unit of Measurement")]
        public string UnitOfMeasurement { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        [Display(Name = "Last Delivery")]
        public DateTime? LastDelivery { get; set; }

        [ForeignKey("Employee")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [NotMapped]
        [Display(Name = "Total Items in Stock")]
        public int TotalItemInStock { get { return WarehouseInventoryItems.Sum(m => m.ItemCount); } }


        public Employee Employee { get; set; }
        public List<WarehouseInventoryItem> WarehouseInventoryItems { get; set; } = new List<WarehouseInventoryItem>();
    }
}
