using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class VendorIndexViewModel
    {
        public string VVendorName { get; set; }
        public string VCompanyName { get; set; }
        public IEnumerable<Flowpoint_Support_Ticket> Flowpoint_Support_Tickets { get; set; }
    }
}
