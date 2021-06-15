using Crud_FP.Data;
using Crud_FP.Data.Repositories;
using Crud_FP.Models;
using Crud_FP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Controllers
{
    public class VendorController : Controller
    {

        private readonly IVendorRepository _vendorRepository;

        private readonly ApplicationDBContext _db;

        public VendorController(IVendorRepository vendorRepository, ApplicationDBContext db)
        {
            _vendorRepository = vendorRepository;
            _db = db;
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
                    Vendors = vendor,
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
        public IActionResult Create()
        {
            VendorDetailViewModel viewModel = new VendorDetailViewModel()
            {
                CompanyDropDown = _db.Flowpoint_Support_Companies.Select(i => new SelectListItem
                {
                    Text = i.VCompanyName,
                    Value = i.ICompanyID.ToString()
                })
            };

            return View(viewModel);
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendorDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flowpoint_Support_Vendor createVendor = new Flowpoint_Support_Vendor()
                {
                    IVendorID = model.IVendorID,
                    ICompanyID = model.ICompanyID,
                    VVendorName = model.VVendorName,
                    VStreet1 = model.VStreet1,
                    VStreet2 = model.VStreet2,
                    VCity = model.VCity,
                    VProvince = model.VProvince,
                    VPostalCode = model.VPostalCode,
                    VCountry = model.VCountry,
                    VContact = model.VContact,
                    VPhone = model.VPhone,
                    VEmail = model.VEmail,
                    DtCreated = model.DtCreated,
                    BlsActive = model.BlsActive
                };

                _vendorRepository.AddVendor(createVendor);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //get delete
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Vendor vendor = _vendorRepository.GetVendor(id);
            if (vendor == null)
            {
                return NotFound();
            }

            VendorDetailViewModel viewmodel = new VendorDetailViewModel()
            {
                IVendorID = vendor.IVendorID,
                ICompanyID = vendor.ICompanyID,
                VVendorName = vendor.VVendorName,
                VStreet1 = vendor.VStreet1,
                VStreet2 = vendor.VStreet2,
                VCity = vendor.VCity,
                VProvince = vendor.VProvince,
                VPostalCode = vendor.VPostalCode,
                VCountry = vendor.VCountry,
                VContact = vendor.VContact,
                VPhone = vendor.VPhone,
                VFax = vendor.VFax,
                VEmail = vendor.VEmail,
                DtCreated = vendor.DtCreated,
                BlsActive = vendor.BlsActive
            };
            return View(viewmodel);

        }

        //Post Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _vendorRepository.DeleteVendor(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Vendor vendor = _vendorRepository.GetVendor(id);
            if (vendor == null)
            {
                return NotFound();
            }

            VendorDetailViewModel viewmodel = new VendorDetailViewModel()
            {
                IVendorID = vendor.IVendorID,
                VVendorName = vendor.VVendorName,
                VStreet1 = vendor.VStreet1,
                VStreet2 = vendor.VStreet2,
                VCity = vendor.VCity,
                VProvince = vendor.VProvince,
                VPostalCode = vendor.VPostalCode,
                VCountry = vendor.VCountry,
                VContact = vendor.VContact,
                VPhone = vendor.VPhone,
                VFax = vendor.VFax,
                VEmail = vendor.VEmail,
                DtCreated = vendor.DtCreated,
                BlsActive = vendor.BlsActive,

                CompanyDropDown = _db.Flowpoint_Support_Companies.Select(i => new SelectListItem
                {
                    Text = i.VCompanyName,
                    Value = i.ICompanyID.ToString()
                })
            };
            return View(viewmodel);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(VendorDetailViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {

                Flowpoint_Support_Vendor vendor = new Flowpoint_Support_Vendor()
                {
                    ICompanyID = viewmodel.ICompanyID,
                    IVendorID =viewmodel.IVendorID,
                    VVendorName = viewmodel.VVendorName,
                    VStreet1 = viewmodel.VStreet1,
                    VStreet2 = viewmodel.VStreet2,
                    VCity = viewmodel.VCity,
                    VProvince = viewmodel.VProvince,
                    VPostalCode = viewmodel.VPostalCode,
                    VCountry = viewmodel.VCountry,
                    VContact = viewmodel.VContact,
                    VPhone = viewmodel.VPhone,
                    VFax = viewmodel.VFax,
                    VEmail = viewmodel.VEmail,
                    DtCreated = viewmodel.DtCreated,
                    BlsActive = viewmodel.BlsActive
                };

                _vendorRepository.UpdateVendor(vendor);
                return RedirectToAction("Index");

            }
            return View(viewmodel);

        }

        public IActionResult Detail(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            var vendor = _vendorRepository.GetVendor(id);
            if (vendor == null)
            {
                return NotFound();
            }

            VendorDetailViewModel viewmodel = new VendorDetailViewModel()
            {
                ICompanyID = vendor.ICompanyID,
                IVendorID = vendor.IVendorID,
                VVendorName = vendor.VVendorName,
                VStreet1 = vendor.VStreet1,
                VStreet2 = vendor.VStreet2,
                VCity = vendor.VCity,
                VProvince = vendor.VProvince,
                VPostalCode = vendor.VPostalCode,
                VCountry = vendor.VCountry,
                VContact = vendor.VContact,
                VPhone = vendor.VPhone,
                VFax = vendor.VFax,
                VEmail = vendor.VEmail,
                DtCreated = vendor.DtCreated,
                BlsActive = vendor.BlsActive,
            };
            return View(viewmodel);

        }
    }
}
