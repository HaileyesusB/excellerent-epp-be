using Excellerent.ApplicantTracking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Excellerent.SharedModules.Seed.IAsyncRepository;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Repository
{
    public interface IApplicantRepository : IAsyncRepository<Applicant>
    {
        Task<IEnumerable<Applicant>> GetApplicantByCountry(string country);


    }
}
