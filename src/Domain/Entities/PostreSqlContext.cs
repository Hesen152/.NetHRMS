using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class PostreSqlContext : DbContext
    {
        public PostreSqlContext()
        {
        }

        public PostreSqlContext(DbContextOptions<PostreSqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CompanyStaff> CompanyStaffs { get; set; }
        public virtual DbSet<CompanyStaffVerification> CompanyStaffVerifications { get; set; }
        public virtual DbSet<EmailActivation> EmailActivations { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<EmployerUpdate> EmployerUpdates { get; set; }
        public virtual DbSet<JobAdvert> JobAdverts { get; set; }
        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<JobSeeker> JobSeekers { get; set; }
        public virtual DbSet<JobSeekerCv> JobSeekerCvs { get; set; }
        public virtual DbSet<JobSeekerCvEducation> JobSeekerCvEducations { get; set; }
        public virtual DbSet<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
        public virtual DbSet<JobSeekerCvImage> JobSeekerCvImages { get; set; }
        public virtual DbSet<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
        public virtual DbSet<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public virtual DbSet<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        public virtual DbSet<JobSeekersFavoriteJobAdvert> JobSeekersFavoriteJobAdverts { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MernisActivation> MernisActivations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WebSite> WebSites { get; set; }
        public virtual DbSet<WorkingTime> WorkingTimes { get; set; }
        public virtual DbSet<WorkingType> WorkingTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=HRMSDatabase.SQL;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostreSqlContext).Assembly);
            

            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CompanyStaff>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("company_staffs_pkey");

                entity.ToTable("company_staffs");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CompanyStaff)
                    .HasForeignKey<CompanyStaff>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("company_staffs_user_id_fkey");
            });

            modelBuilder.Entity<CompanyStaffVerification>(entity =>
            {
                entity.ToTable("company_staff_verifications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("time with time zone")
                    .HasColumnName("approval_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompanyStaffVerifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("company_staff_verifications_user_id_fkey");
            });

            modelBuilder.Entity<EmailActivation>(entity =>
            {
                entity.ToTable("email_activations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ActivationCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("activation_code");

                entity.Property(e => e.ActivationDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("activation_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.IsActivated).HasColumnName("is_activated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmailActivations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("email_activations_user_id_fkey");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("employers_pkey");

                entity.ToTable("employers");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("company_name");

                entity.Property(e => e.CorporateEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("corporate_email");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("website");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Employer)
                    .HasForeignKey<Employer>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employers_user_id_fkey");
            });

            modelBuilder.Entity<EmployerUpdate>(entity =>
            {
                entity.ToTable("employer_updates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyStaffId).HasColumnName("company_staff_id");

                entity.Property(e => e.CorporateEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("corporate_email");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("website");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployerUpdates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employer_updates_user_id_fkey");
            });

            modelBuilder.Entity<JobAdvert>(entity =>
            {
                entity.ToTable("job_adverts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ApplicationDeadline)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("application_deadline");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.EmployerId).HasColumnName("employer_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.JobPositionId).HasColumnName("job_position_id");

                entity.Property(e => e.MaxSalary).HasColumnName("max_salary");

                entity.Property(e => e.MinSalary).HasColumnName("min_salary");

                entity.Property(e => e.NumberOfOpenPositions).HasColumnName("number_of_open_positions");

                entity.Property(e => e.WorkingTimeId).HasColumnName("working_time_id");

                entity.Property(e => e.WorkingTypeId).HasColumnName("working_type_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.JobAdverts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_adverts_city_id_fkey");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.JobAdverts)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_adverts_employer_id_fkey");

                entity.HasOne(d => d.JobPosition)
                    .WithMany(p => p.JobAdverts)
                    .HasForeignKey(d => d.JobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_adverts_job_position_id_fkey");

                entity.HasOne(d => d.WorkingTime)
                    .WithMany(p => p.JobAdverts)
                    .HasForeignKey(d => d.WorkingTimeId)
                    .HasConstraintName("job_adverts_working_time_id_fkey");

                entity.HasOne(d => d.WorkingType)
                    .WithMany(p => p.JobAdverts)
                    .HasForeignKey(d => d.WorkingTypeId)
                    .HasConstraintName("job_adverts_working_type_id_fkey");
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.ToTable("job_positions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("job_seekers_pkey");

                entity.ToTable("job_seekers");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CvId).HasColumnName("cv_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("identity_number")
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.Cv)
                    .WithMany(p => p.JobSeekers)
                    .HasForeignKey(d => d.CvId)
                    .HasConstraintName("job_seekers_cv_id_fkey");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.JobSeeker)
                    .HasForeignKey<JobSeeker>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seekers_user_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCv>(entity =>
            {
                entity.ToTable("job_seeker_cvs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CoverLetter)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("cover_letter");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobSeekerId).HasColumnName("job_seeker_id");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany(p => p.JobSeekerCvs)
                    .HasForeignKey(d => d.JobSeekerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cvs_job_seeker_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvEducation>(entity =>
            {
                entity.ToTable("job_seeker_cv_educations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("department_name");

                entity.Property(e => e.GraduationDate)
                    .HasColumnType("date")
                    .HasColumnName("graduation_date");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("school_name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvEducations)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_educations_job_seeker_cv_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvExperience>(entity =>
            {
                entity.ToTable("job_seeker_cv_experiences");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobPositionId).HasColumnName("job_position_id");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.QuitDate)
                    .HasColumnType("date")
                    .HasColumnName("quit_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.WorkplaceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("workplace_name");

                entity.HasOne(d => d.JobPosition)
                    .WithMany(p => p.JobSeekerCvExperiences)
                    .HasForeignKey(d => d.JobPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_experiences_job_position_id_fkey");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvExperiences)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_experiences_job_seeker_cv_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvImage>(entity =>
            {
                entity.ToTable("job_seeker_cv_images");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("url");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvImages)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_images_job_seeker_cv_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvLanguage>(entity =>
            {
                entity.ToTable("job_seeker_cv_languages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("language_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Level).HasColumnName("level");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvLanguages)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_languages_job_seeker_cv_id_fkey");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.JobSeekerCvLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_languages_language_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvSkill>(entity =>
            {
                entity.ToTable("job_seeker_cv_skills");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvSkills)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_skills_job_seeker_cv_id_fkey");
            });

            modelBuilder.Entity<JobSeekerCvWebSite>(entity =>
            {
                entity.ToTable("job_seeker_cv_web_sites");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.JobSeekerCvId).HasColumnName("job_seeker_cv_id");

                entity.Property(e => e.WebSiteId).HasColumnName("web_site_id");

                entity.HasOne(d => d.JobSeekerCv)
                    .WithMany(p => p.JobSeekerCvWebSites)
                    .HasForeignKey(d => d.JobSeekerCvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_web_sites_job_seeker_cv_id_fkey");

                entity.HasOne(d => d.WebSite)
                    .WithMany(p => p.JobSeekerCvWebSites)
                    .HasForeignKey(d => d.WebSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seeker_cv_web_sites_web_site_id_fkey");
            });

            modelBuilder.Entity<JobSeekersFavoriteJobAdvert>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("job_seekers_favorite_job_adverts");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.JobAdvertId).HasColumnName("job_advert_id");

                entity.Property(e => e.JobSeekerId).HasColumnName("job_seeker_id");

                entity.HasOne(d => d.JobAdvert)
                    .WithMany()
                    .HasForeignKey(d => d.JobAdvertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seekers_favorite_job_adverts_job_advert_id_fkey");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany()
                    .HasForeignKey(d => d.JobSeekerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_seekers_favorite_job_adverts_job_seeker_id_fkey");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");

                entity.Property(e => e.Id)
                    .HasMaxLength(2)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MernisActivation>(entity =>
            {
                entity.ToTable("mernis_activations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("time with time zone")
                    .HasColumnName("approval_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsApproved).HasColumnName("is_approved");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MernisActivations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mernis_activations_user_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<WebSite>(entity =>
            {
                entity.ToTable("web_sites");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkingTime>(entity =>
            {
                entity.ToTable("working_times");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkingType>(entity =>
            {
                entity.ToTable("working_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
