using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace NTierIMS.Core.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage ="Maximum Lenght is 200 characters")]
        [Required(ErrorMessage = "This Field is required")]
        public string Name { get; set; }
        [StringLength(350, ErrorMessage ="Maximum Lenght is 350 characters")]
        public string Address { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        [ForeignKey("Employee")]
        public string CreatedBy { get; set; }

    }
}
