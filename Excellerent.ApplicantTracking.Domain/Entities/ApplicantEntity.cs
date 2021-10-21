using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ApplicantTracking.Domain.Entities
{
    public class ApplicantEntity : BaseEntity<Applicant>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ApplicantEntity()
        {

        }
        public ApplicantEntity(Applicant applicant) : base(applicant)
        {
            CreatedDate = applicant.Createddate;
            FirstName = applicant.FirstName;
            LastName = applicant.LastName;
            Email = applicant.Email;
            Password = applicant.Password;

        }

        public override Applicant MapToModel()
        {
            Applicant applicant = new Applicant();
            applicant.FirstName = FirstName;
            applicant.LastName = LastName;
            applicant.Createddate = CreatedDate;
            applicant.Guid = Guid.NewGuid();
            applicant.Country = Country;
            applicant.Email = Email;
            applicant.Password = Password;
            applicant.IsActive = IsActive;
            applicant.IsDeleted = IsDeleted;
            return applicant;
        }

        public override Applicant MapToModel(Applicant t)
        {
            Applicant applicantToUpdate = t;
            applicantToUpdate.FirstName = FirstName;
            applicantToUpdate.LastName = LastName;
            applicantToUpdate.Createddate = CreatedDate;
            applicantToUpdate.Guid = Guid;
            applicantToUpdate.Country = Country;
            applicantToUpdate.Email = Email;
            applicantToUpdate.IsActive = IsActive;
            applicantToUpdate.IsDeleted = IsDeleted;
            return applicantToUpdate;
        }
    }
}
