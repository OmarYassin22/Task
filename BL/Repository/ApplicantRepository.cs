using BL.Interfaces;
using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.ApplicationRepo
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly AppDbContext _context;
        private readonly ICountryValidService _countryValidService;

        public ApplicantRepository(AppDbContext context, ICountryValidService countryValidService)
        {
            _context = context;
            _countryValidService = countryValidService;
        }

        public async Task<int> AddAsync(Applicant applicant)
        {



            if (!await _countryValidService.IsVaild(applicant.CountryOfOrigin))
            {
                return 0;
            }
            _context.Applicants.Add(applicant);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return 0;
            }
            _context.Applicants.Remove(applicant);
            return await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetAsync(int id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task<IEnumerable<Applicant>> GetAll()
        {
            var apps = await _context.Applicants.ToListAsync();
            if (apps == null)
            {
                return null;
            }
            return apps;
        }

        public async Task<int> UpdateAsync(Applicant applicant)
        {
            if (!await _countryValidService.IsVaild(applicant.CountryOfOrigin))
            {
                return 0;
            }
            _context.Applicants.Update(applicant);
            return await _context.SaveChangesAsync();
        }


    }
}
