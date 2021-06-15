using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class TicketDetailViewModel
    {
        public Flowpoint_Support_Ticket flowpoint_Support_Ticket { get; set; }
        public string VVendorName { get; set; }
    }
}
