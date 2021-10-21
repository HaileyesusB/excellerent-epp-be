using Excellerent.ApplicantTracking.Domain.Interfaces.Repository;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Infrastructure.Repositories
{
    public class ApplicantRepository : AsyncRepository<Applicant>, IApplicantRepository
    {
        private readonly EPPContext _context;
        public ApplicantRepository(EPPContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Applicant>> GetApplicantByCountry(string country)
        {
            try
            {
                IEnumerable<Applicant> applicant = (await base.GetQueryAsync(x => x.Country == country)).ToList();
                return applicant;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
