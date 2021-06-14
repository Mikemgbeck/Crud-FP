using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Models
{
    public class Flowpoint_Support_Ticket
    {
        [Key]
        public int ITicketID { get; set; }

        [StringLength(3000, ErrorMessage = "The {0} value cannot exceed {1}characters ")]
        [Required(ErrorMessage = "Ticket Message is required ")]
        public string VTicketMessage { get; set; }

        [Required(ErrorMessage = "Created Date is required ")]
        public DateTime DtCreatedDate { get; set; }

        [Required(ErrorMessage = "Modified Date is required ")]
        public DateTime DtModifiedDate { get; set; }

        [Required(ErrorMessage = "Created By is required ")]
        public int ICreatedBy { get; set; }

        [Required(ErrorMessage = "Modified By is required ")]
        public int IModifiedBy { get; set; }

        [Required(ErrorMessage = "BlsActive is required ")]
        public bool BlsActive { get; set; }

        public int IVendorID { get; set; }

        [ForeignKey("IVendorID")]
        public virtual Flowpoint_Support_Vendor Flowpoint_Support_Vendor { get; set; }
    }
}
