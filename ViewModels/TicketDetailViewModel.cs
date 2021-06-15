using Crud_FP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class TicketDetailViewModel
    {
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

        public IEnumerable<SelectListItem> VendorDropDown { get; set; }
    }
}
