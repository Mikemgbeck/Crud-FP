using Crud_FP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ApplicationDBContext _context;
        public VendorRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddVendor(Flowpoint_Support_Vendor newVendor)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVendor(int vendorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flowpoint_Support_Vendor>> GetAllVendors(string searchText)
        {
            List<Flowpoint_Support_Vendor> vendors = null;

            if (string.IsNullOrEmpty(searchText))
            {
                vendors = await _context.Flowpoint_Support_Vendors.ToListAsync();
            }
            else
            {
                vendors = await _context.Flowpoint_Support_Vendors
                                    .Where(x => x.VVendorName.ToLower()
                                    .Contains(searchText.ToLower()))
                                    .ToListAsync();
            }

            return vendors;
        }

        public Flowpoint_Support_Vendor GetVendor(int vendorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flowpoint_Support_Vendor>> GetVendorByID(int vendorID)
        {
            List<Flowpoint_Support_Vendor> vendor = null;
            vendor = await _context.Flowpoint_Support_Vendors.Where(x => x.IVendorID.Equals(vendorID)).ToListAsync();

            if (vendor == null)
            {
                throw new Exception("No Vendor found under the provided ID");
            }

            return vendor;
        }

        public Flowpoint_Support_Vendor UpdateVendor(Flowpoint_Support_Vendor editedVendor)
        {
            throw new NotImplementedException();
        }
    }
}
