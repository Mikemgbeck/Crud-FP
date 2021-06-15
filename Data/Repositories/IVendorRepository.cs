using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public interface IVendorRepository
    {
        Task<List<Flowpoint_Support_Vendor>> GetAllVendors(string searchText);
        Task<List<Flowpoint_Support_Vendor>> GetVendorByID(int vendorID);
        Flowpoint_Support_Vendor GetVendor(int vendorId);
        Task AddVendor(Flowpoint_Support_Vendor newVendor);
        void UpdateVendor(Flowpoint_Support_Vendor editedVendor);
        void DeleteVendor(int vendorId);
    }
}
