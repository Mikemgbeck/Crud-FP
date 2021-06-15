using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class TicketIndexViewModel
    {

        public int ITicketID { get; set; }
        [StringLength(3000, ErrorMessage = "The {0} value cannot exceed {1}characters ")]
        [Required(ErrorMessage = "Ticket Message is required ")]
        public string VTicketMessage { get; set; }

        [Required(ErrorMessage = "BlsActive is required ")]
        public bool BlsActive { get; set; }
    }
}
