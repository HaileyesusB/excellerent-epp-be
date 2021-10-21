using Excellerent.ApplicantTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Service
{
    public interface IApplicantService
    {
        Task<IEnumerable<ApplicantEntity>> GetApplicantsByCountry(string country);

        Task<Guid> AddAsync(ApplicantEntity applicantEntity);
        Task UpdateAsync(ApplicantEntity applicantEntity);
        Task<ApplicantEntity> GetByIdAsync(Guid guid);
        Task<IEnumerable<ApplicantEntity>> GetAllApplicant();
           }
}
