using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class CompanyIndexViewModel
    {
        public IEnumerable<Flowpoint_Support_Company> Companies { get; set; }
    }
}
