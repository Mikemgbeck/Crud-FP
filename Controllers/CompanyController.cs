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
    public class CompanyController : Controller
    {

        private readonly ICompanyRepository _companyRepository;


        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IActionResult> Index(string searchText, int searchID)
        {
            ViewData["searchText"] = searchText;
            ViewData["searchID"] = searchID;

            List<Flowpoint_Support_Company> companies = null;
            List<Flowpoint_Support_Company> company = null;

            if (searchID != 0)
            {
                company =  await _companyRepository.GetCompanyByID(searchID);
                CompanyIndexViewModel model = new CompanyIndexViewModel()
                {
                    Companies = company
                };

                return View(model);
            }
            else
            {
                companies = await _companyRepository.GetAllCompanies(searchText);

                CompanyIndexViewModel model = new CompanyIndexViewModel()
                {
                    Companies = companies
                };

                return View(model);
            }


        }
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flowpoint_Support_Company Company = new Flowpoint_Support_Company
                {
                    VCompanyName = model.VCompanyName,
                    VStreet1 = model.VStreet1,
                    VStreet2 = model.VStreet2,
                    VCity = model.VCity,
                    VProvince = model.VProvince,
                    VPostalCode = model.VPostalCode,
                    VCountry = model.VCountry,
                    VContact = model.VContact,
                    VPhone = model.VPhone,
                    VFax = model.VFax,
                    VEmail = model.VEmail,
                    DtCreated = model.DtCreated,
                    BlsActive = model.BlsActive
                };
                _companyRepository.AddCompany(Company);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Get Delete
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Company company = _companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            CompanyDetailViewModel viewmodel = new CompanyDetailViewModel()
            {
                ICompanyID = company.ICompanyID,
                VCompanyName = company.VCompanyName,
                VStreet1 = company.VStreet1,
                VStreet2 = company.VStreet2,
                VCity = company.VCity,
                VProvince = company.VProvince,
                VPostalCode = company.VPostalCode,
                VCountry = company.VCountry,
                VContact = company.VContact,
                VPhone = company.VPhone,
                VFax = company.VFax,
                VEmail = company.VEmail,
                DtCreated = company.DtCreated,
                BlsActive = company.BlsActive
            };
            return View(viewmodel);

        }

        //Post Delete

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _companyRepository.DeleteCompany(id);
            return RedirectToAction("Index");
        }
        //get update

        public IActionResult Update(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Company company = _companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            CompanyDetailViewModel viewmodel = new CompanyDetailViewModel()
            {
                ICompanyID = company.ICompanyID,
                VCompanyName = company.VCompanyName,
                VStreet1 = company.VStreet1,
                VStreet2 = company.VStreet2,
                VCity = company.VCity,
                VProvince = company.VProvince,
                VPostalCode = company.VPostalCode,
                VCountry = company.VCountry,
                VContact = company.VContact,
                VPhone = company.VPhone,
                VFax = company.VFax,
                VEmail = company.VEmail,
                DtCreated = company.DtCreated,
                BlsActive = company.BlsActive
            };
            return View(viewmodel);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CompanyDetailViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {

                Flowpoint_Support_Company company = new Flowpoint_Support_Company()
                {
                    ICompanyID = viewmodel.ICompanyID,
                    VCompanyName = viewmodel.VCompanyName,
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

                _companyRepository.UpdateCompany(company);
                return RedirectToAction("Index");

            }
            return View(viewmodel);

        }

        public IActionResult Detail(int id)
        {

            if  (id == 0)
            {
                return NotFound();
            }
            var company = _companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            CompanyDetailViewModel viewmodel = new CompanyDetailViewModel()
            {
                ICompanyID = company.ICompanyID,
                VCompanyName = company.VCompanyName,
                VStreet1 = company.VStreet1,
                VStreet2 = company.VStreet2,
                VCity = company.VCity,
                VProvince = company.VProvince,
                VPostalCode = company.VPostalCode,
                VCountry = company.VCountry,
                VContact = company.VContact,
                VPhone = company.VPhone,
                VFax = company.VFax,
                VEmail = company.VEmail,
                DtCreated = company.DtCreated,
                BlsActive = company.BlsActive
            };
            return View(viewmodel);

        }
    }
}
