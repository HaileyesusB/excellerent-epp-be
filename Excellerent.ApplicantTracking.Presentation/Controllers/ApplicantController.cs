using Excellerent.APIModularization.Controllers;
using Excellerent.APIModularization.Logging;
using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicantController : AuthorizedController
    {

        private readonly IApplicantService _applicantService;
        public ApplicantController(IHttpContextAccessor htttpContextAccessor, IConfiguration configuration, IBusinessLog _businessLog, string feature, IApplicantService applicantService) : base(htttpContextAccessor, configuration, _businessLog, feature)
        {
            _applicantService = applicantService;
        }

        [HttpGet("ApplicantByCountryy/{country?}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ApplicantEntity>>> GetAllApplicantByCountry(string country)
        {
            try
            {
                var result = await _applicantService.GetApplicantsByCountry(country);
                return Ok(result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

    }
}
