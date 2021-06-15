using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class VendorIndexViewModel
    {
        public IEnumerable<Flowpoint_Support_Vendor> Vendors { get; set; }
    }
}
