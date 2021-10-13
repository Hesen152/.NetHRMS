using dotnethrmsmy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace dotnethrmsmy.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }
        public  DbSet<City> Cities { get; set; }
        public  DbSet<CompanyStaff> CompanyStaffs { get; set; }
        public  DbSet<CompanyStaffVerification> CompanyStaffVerifications { get; set; }
        public  DbSet<EmailActivation> EmailActivations { get; set; }
        public  DbSet<Employer> Employers { get; set; }
        public  DbSet<EmployerUpdate> EmployerUpdates { get; set; }
        public  DbSet<JobAdvert> JobAdverts { get; set; }
        public  DbSet<JobPosition> JobPositions { get; set; }
        public  DbSet<JobSeeker> JobSeekers { get; set; }
        public  DbSet<JobSeekerCv> JobSeekerCvs { get; set; }
        public  DbSet<JobSeekerCvEducation> JobSeekerCvEducations { get; set; }
        public  DbSet<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
        public  DbSet<JobSeekerCvImage> JobSeekerCvImages { get; set; }
        public  DbSet<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
        public  DbSet<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public  DbSet<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        public  DbSet<JobSeekersFavoriteJobAdvert> JobSeekersFavoriteJobAdverts { get; set; }
        public  DbSet<Language> Languages { get; set; }
        public  DbSet<MernisActivation> MernisActivations { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<WebSite> WebSites { get; set; }
        public  DbSet<WorkingTime> WorkingTimes { get; set; }
        public  DbSet<WorkingType> WorkingTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
