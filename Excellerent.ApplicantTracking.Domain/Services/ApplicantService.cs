using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Interfaces.Repository;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Services
{
    public class ApplicantService : CRUD<ApplicantEntity,Applicant>, IApplicantService 
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly ILogger<ApplicantService> _logger;
        public ApplicantService(IApplicantRepository applicantRepository, ILogger<ApplicantService> logger) :base(applicantRepository)
        {
            _applicantRepository = applicantRepository;
            _logger = logger;
        }

        public async Task<Guid> AddAsync(ApplicantEntity applicantEntity)
        {
            var model = applicantEntity.MapToModel();
            var data = await _applicantRepository.AddAsync(model);
            return data.Guid;
        }

        public async Task<IEnumerable<ApplicantEntity>> GetAllApplicant()
        {
            var applicant = await _applicantRepository.GetAllAsync();
            return applicant?.Select(o => new ApplicantEntity(o)).ToList();
        }

        public async Task<IEnumerable<ApplicantEntity>> GetApplicantsByCountry(string country)
        {
            try
            {
                var applicantCountry = (await _applicantRepository.GetQueryAsync(x => x.Country == country)).ToList();
                return applicantCountry?.Select(x => new ApplicantEntity(x));
            }
            catch (Exception e)
            {

                _logger.LogError($"Error Occured : {e.Message}");
                return Enumerable.Empty<ApplicantEntity>();
            }

        }

        public async Task<ApplicantEntity> GetByIdAsync(Guid guid)
        {
            var applicant = await _applicantRepository.GetByGuidAsync(guid);
            return new ApplicantEntity(applicant);
        }

        public async Task UpdateAsync(ApplicantEntity applicantEntity)
        {
            try
            {
                await _applicantRepository.UpdateAsync(applicantEntity.MapToModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Error Occured : {e.Message}");
            }
        }
    }
}
