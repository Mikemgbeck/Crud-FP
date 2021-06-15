using Crud_FP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDBContext _context;
        public CompanyRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddCompany(Flowpoint_Support_Company newCompany)
        {
            await _context.Flowpoint_Support_Companies.AddAsync(newCompany);
            _context.SaveChanges();
        }

        public void DeleteCompany(int companyId)
        {
            Flowpoint_Support_Company company = _context.Flowpoint_Support_Companies.Find(companyId);
            if (company != null)
            {
               _context.Flowpoint_Support_Companies.Remove(company);
               _context.SaveChangesAsync();
            }
        }

        public async Task<List<Flowpoint_Support_Company>> GetAllCompanies(string searchText)
        {

            List<Flowpoint_Support_Company> companies = null;

            if (string.IsNullOrEmpty(searchText))
            {
                companies = await _context.Flowpoint_Support_Companies.ToListAsync();
            }
            else
            {
                companies = await _context.Flowpoint_Support_Companies
                                    .Where(x => x.VCompanyName.ToLower()
                                    .Contains(searchText.ToLower()))
                                    .ToListAsync();
            }

            return companies;
        }

        public Flowpoint_Support_Company GetCompany(int companyId)
        {
            Flowpoint_Support_Company company = null;
            company = _context.Flowpoint_Support_Companies.Find(companyId);

            if (company == null)
            {
                throw new Exception("No image found under the provided ID");
            }

            return company;
        }

        public async Task<List<Flowpoint_Support_Company>> GetCompanyByID(int companyID)
        {
            List<Flowpoint_Support_Company> company = null;
            company = await _context.Flowpoint_Support_Companies.Where(x => x.ICompanyID.Equals(companyID)).ToListAsync();

            if (company == null)
            {
                throw new Exception("No company found under the provided ID");
            }

            return company;
        }

        public Flowpoint_Support_Company UpdateCompany(Flowpoint_Support_Company editedCompany)
        {
            var flowpoint_Support_Company = _context.Flowpoint_Support_Companies.Attach(editedCompany);
            flowpoint_Support_Company.State = EntityState.Modified;
            _context.SaveChanges();
            return editedCompany;
        }
    }
}
