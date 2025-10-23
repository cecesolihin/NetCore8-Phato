using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Models.Organization;
using ThePatho.Infrastructure.Persistance.Configuration.Global;
using ThePatho.Infrastructure.Persistance.Configuration.Identity;
using ThePatho.Infrastructure.Persistance.Configuration.Organization;
using ThePatho.Infrastructure.Persistance.Configuration.PersonalInformation;


namespace ThePatho.Infrastructure.Persistance
{
    public partial class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region [IDENTITY]
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region [ORGANIZATION]
        public DbSet<JobLevel> JobLevels { get; set; }
        public DbSet<OrgLevel> OrganizationLevels { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet<Position> Positions { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [IDENTITY]
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            #endregion

            #region [ORGANIZATION]
            modelBuilder.ApplyConfiguration(new CompanyBankConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProfileConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new HistOrgStructureConfiguration());
            modelBuilder.ApplyConfiguration(new JabatanConfiguration());
            modelBuilder.ApplyConfiguration(new JobClassConfiguration());
            modelBuilder.ApplyConfiguration(new JobLevelConfiguration());
            modelBuilder.ApplyConfiguration(new JobLevelJobClassConfiguration());
            modelBuilder.ApplyConfiguration(new MutationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrgLevelConfiguration());
            modelBuilder.ApplyConfiguration(new OrgStructureConfiguration());
            modelBuilder.ApplyConfiguration(new PensionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new RankConfiguration());
            modelBuilder.ApplyConfiguration(new ResignTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TerminationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkLocationGroupConfiguration());
            modelBuilder.ApplyConfiguration(new WorkLocationsConfiguration());
            modelBuilder.ApplyConfiguration(new CostCenterConfiguration());
            #endregion


            #region [PERSONEL INFORMATION]
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EduLevelConfiguration());
            modelBuilder.ApplyConfiguration(new EduMajorConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeAddressConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeCapColorConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeCareerHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeCustomFieldConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeDocumentsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEducationsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeIdentityConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeInventoryConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeMedicalConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePersonalDataConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePickUpConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePunishmentsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRewardConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeSetPickUpConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeSetPickUpDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeSkillsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTrainingConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeWorkingExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyRelationsConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryGroupConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryGroupDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryGroupOrgConfiguration());
            #endregion

            #region [GLOBAL]
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new BloodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BranchBankConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ClothSizeConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new GraduationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConditionConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LetterCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LetterTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new MaritalStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalGroupConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityConfiguration());
            modelBuilder.ApplyConfiguration(new NumericalSizeConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new PunishmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReligionConfiguration());
            modelBuilder.ApplyConfiguration(new ResignReasonConfiguration());
            modelBuilder.ApplyConfiguration(new RewardTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RomanianSizeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new ShoeSizeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateKeywordConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new TaxStatusConfiguration());
            #endregion
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
