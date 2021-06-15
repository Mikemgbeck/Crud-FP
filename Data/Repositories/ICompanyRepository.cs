using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Flowpoint_Support_Company>> GetAllCompanies(string searchText);
        Task<List<Flowpoint_Support_Company>> GetCompanyByID(int CompanyID);
        Flowpoint_Support_Company GetCompany(int companyId);
        Task AddCompany(Flowpoint_Support_Company newCompany);
        Flowpoint_Support_Company UpdateCompany(Flowpoint_Support_Company editedCompany);
        Task DeleteCompany(int companyId);
    }
}
