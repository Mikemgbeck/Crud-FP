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
            await _context.Flowpoint_Support_Vendors.AddAsync(newVendor);
            _context.SaveChanges();
        }

        public void DeleteVendor(int vendorId)
        {
            Flowpoint_Support_Vendor vendor = _context.Flowpoint_Support_Vendors.Find(vendorId);
            if (vendor != null)
            {
                _context.Flowpoint_Support_Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }

        public async Task<List<Flowpoint_Support_Vendor>> GetAllVendors(string searchText)
        {
            List<Flowpoint_Support_Vendor> vendors = null;

            if (string.IsNullOrEmpty(searchText))
            {
                vendors = await _context.Flowpoint_Support_Vendors.Include(c => c.Flowpoint_Support_Company).ToListAsync();
            }
            else
            {
                vendors = await _context.Flowpoint_Support_Vendors
                                    .Where(x => x.VVendorName.ToLower()
                                    .Contains(searchText.ToLower()))
                                    .Include(c => c.Flowpoint_Support_Company)
                                    .ToListAsync();
            }

            return vendors;
        }

        public Flowpoint_Support_Vendor GetVendor(int vendorId)
        {
            Flowpoint_Support_Vendor vendor = null;
            vendor = _context.Flowpoint_Support_Vendors.Find(vendorId);

            if (vendor == null)
            {
                throw new Exception("No vendor found under the provided ID");
            }

            return vendor;
        }

        public async Task<List<Flowpoint_Support_Vendor>> GetVendorByID(int vendorID)
        {
            List<Flowpoint_Support_Vendor> vendor = null;
            vendor = await _context.Flowpoint_Support_Vendors.Where(x => x.IVendorID.Equals(vendorID)).Include(c =>c.Flowpoint_Support_Company).ToListAsync();

            if (vendor == null)
            {
                throw new Exception("No Vendor found under the provided ID");
            }

            return vendor;
        }

        public void UpdateVendor(Flowpoint_Support_Vendor editedVendor)
        {
            var flowpoint_Support_Vendor = _context.Flowpoint_Support_Vendors.Attach(editedVendor);
            flowpoint_Support_Vendor.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
