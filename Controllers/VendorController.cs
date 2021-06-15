using Crud_FP.Data.Repositories;
using Crud_FP.Models;
using Crud_FP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Controllers
{
    public class VendorController : Controller
    {

        private readonly IVendorRepository _vendorRepository;


        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<IActionResult> Index(string searchText, int searchID)
        {
            ViewData["searchText"] = searchText;
            ViewData["searchID"] = searchID;

            List<Flowpoint_Support_Vendor> vendors = null;
            List<Flowpoint_Support_Vendor> vendor = null;

            if (searchID != 0)
            {
                vendor = await _vendorRepository.GetVendorByID(searchID);
                VendorIndexViewModel model = new VendorIndexViewModel()
                {
                    Vendors = vendor
                };

                return View(model);
            }
            else
            {
                vendors = await _vendorRepository.GetAllVendors(searchText);

                VendorIndexViewModel model = new VendorIndexViewModel()
                {
                    Vendors = vendors
                };

                return View(model);
            }
        }
    }
}
