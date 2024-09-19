using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IApplicantRepository
    {
        Task<IEnumerable<Applicant>> GetAll();
        Task<Applicant> GetAsync(int id);
        Task<int> AddAsync(Applicant applicant);
        Task<int> UpdateAsync(Applicant applicant);
        Task<int> DeleteAsync(int id);
    }
}
