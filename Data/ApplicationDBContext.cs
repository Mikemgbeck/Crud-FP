using Crud_FP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data
{
    public class ApplicationDBContext :DbContext
    {
            public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
            {

            }


            public DbSet<Flowpoint_Support_Company> Flowpoint_Support_Companies { get; set; }
            public DbSet<Flowpoint_Support_Vendor> Flowpoint_Support_Vendors { get; set; }
            public DbSet<Flowpoint_Support_Ticket> Flowpoint_Support_Tickets { get; set; }
        
    }
}
