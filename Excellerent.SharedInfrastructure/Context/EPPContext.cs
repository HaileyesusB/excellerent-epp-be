using Excellerent.ApplicantTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Excellerent.SharedInfrastructure.Context
{
    public class EPPContext : DbContext
    {
        public EPPContext(DbContextOptions<EPPContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
    }

   
}
