using BL.Interfaces;
using DAL.Data;
using DAL.Model;
using Microsoft.Data.SqlClient;
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

            var result = await AddAPIAsync(applicant);
            if (result == null)
            {
                return 0;
            }
            return 1;

        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {

                var sql = "DELETE FROM Applicants WHERE Id = @Id";
                var parameter = new SqlParameter("@Id", id);

                return _context.Database.ExecuteSqlRaw(sql, parameter);

            }
            catch
            {
                return 0;

            }
        }
        public async Task<Applicant> GetAsync(int id)
        {
            try
            {
                string sql = "select * from Applicants where Id= @Id";
                SqlParameter Id = new SqlParameter("@Id", id);
                return await _context.Applicants.FromSqlRaw(sql, Id).FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Applicant>> GetAllAsync()
        {
            try
            {
                var sql = "select * from Applicants";
                var apps = await _context.Applicants.FromSqlRaw(sql).ToListAsync();

                return apps;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> UpdateAsync(Applicant applicant)
        {
            try
            {

                var sql = "update Applicants set Name=@Name,FamilyName=@FamilyName,Age=@Age,Hired=@Hired,Address=@Address,EmailAdress=@EmailAdress,CountryOfOrigin=@CountryOfOrigin where Id=@Id";
                var paramters = new List<SqlParameter>
                    {
                        new SqlParameter("@Name",applicant.Name),
                        new SqlParameter("@FamilyName",applicant.FamilyName),
                        new SqlParameter("@Age",applicant.Age),
                        new SqlParameter("@Hired",applicant.Hired),
                        new SqlParameter("@Address",applicant.Address),
                        new SqlParameter("@EmailAdress",applicant.EmailAdress),
                        new SqlParameter("@CountryOfOrigin",applicant.CountryOfOrigin),
                        new SqlParameter("@Id",applicant.Id),

                    };
                return _context.Database.ExecuteSqlRaw(sql, paramters.ToArray());
            }
            catch
            {
                return 0;
            }


        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Applicant> AddAPIAsync(Applicant applicant)
        {
            try
            {
                var sql = "INSERT INTO Applicants (Name, FamilyName,Address,CountryOfOrigin,EmailAdress,Age,Hired) VALUES (@Name,@FamilyName,@Address,@CountryOfOrigin,@EmailAdress,@Age,@Hired)";
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Name", applicant.Name),
                    new SqlParameter("@FamilyName", applicant.FamilyName),
                    new SqlParameter("@Address", applicant.Address),
                    new SqlParameter("@CountryOfOrigin", applicant.CountryOfOrigin),
                    new SqlParameter("@EmailAdress", applicant.EmailAdress),
                    new SqlParameter("@Age", applicant.Age),
                    new SqlParameter("@Hired", applicant.Hired),
                };

                if (!await _countryValidService.IsVaild(applicant.CountryOfOrigin))
                {
                    return null;
                }

                _context.Database.ExecuteSqlRaw(sql, parameters.ToArray());
                var addedApplicant = await _context.Applicants.FirstOrDefaultAsync(a => a.Name == applicant.Name && a.FamilyName == applicant.FamilyName);

                return addedApplicant;
            }
            catch
            {
                return null;
            }
        }

        public Task<int> AddAsync(int id, Applicant applicant)
        {
            throw new NotImplementedException();
        }

    }
}
