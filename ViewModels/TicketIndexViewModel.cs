using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.ViewModels
{
    public class TicketIndexViewModel
    {

        public IEnumerable<Flowpoint_Support_Ticket> Tickets { get; set; }
    }
}
