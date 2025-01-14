using Microsoft.EntityFrameworkCore;
using ThePatho.Domain.Models.Applicant;
using ThePatho.Domain.Models.Identity;
using ThePatho.Domain.Models.MasterData;
using ThePatho.Domain.Models.MasterSetting;
using ThePatho.Domain.Models.Organization;
using ThePatho.Domain.Models.Recruitment;
using ThePatho.Infrastructure.Persistance.Configuration.Applicant;
using ThePatho.Infrastructure.Persistance.Configuration.Identity;
using ThePatho.Infrastructure.Persistance.Configuration.MasterData;
using ThePatho.Infrastructure.Persistance.Configuration.MasterSetting;
using ThePatho.Infrastructure.Persistance.Configuration.Organization;
using ThePatho.Infrastructure.Persistance.Configuration.Recruitment;


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

        #region [MASTER DATA]
        public DbSet<AdsCategory> AdsCategories { get; set; }
        public DbSet<AdsMedia> AdsMedias { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        #endregion

        #region [MASTER SETTING]
        public DbSet<OnlineTestSetting> OnlineTestSettings { get; set; }
        public DbSet<QuestionSetting> QuestionSettings { get; set; }
        public DbSet<QuestionSettingDetail> QuestionSettingDetails { get; set; }
        public DbSet<ScoringSetting> ScoringSettings { get; set; }
        public DbSet<ScoringSettingDetail> ScoringSettingDetails { get; set; }
        #endregion

        #region [ORGANIZATION]
        public DbSet<JobLevel> JobLevels { get; set; }
        public DbSet<OrgLevel> OrganizationLevels { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet<Position> Positions { get; set; }
        #endregion

        #region [RECRUITMENT]
        public DbSet<MPP> MPPs { get; set; }
        public DbSet<RequirementMaster> RequirementMasters { get; set; }
        public DbSet<RecruitStep> RecruitSteps { get; set; }
        public DbSet<RecruitStepGroup> RecruitStepGroups { get; set; }
        public DbSet<RecruitStepGroupDetail> RecruitStepGroupDetails { get; set; }
        public DbSet<RecruitmentReqStep> RecruitmentReqSteps { get; set; }
        public DbSet<RecruitmentRequest> RecruitmentRequests { get; set; }
        public DbSet<RequirementRecRequest> RequirementRecRequests { get; set; }
        #endregion

        #region [APPLICANT]
        public DbSet<ApplicantNew> Applicants { get; set; }
        public DbSet<ApplicantAddress> ApplicantAddresses { get; set; }
        public DbSet<ApplicantDocument> ApplicantDocuments { get; set; }
        public DbSet<ApplicantEducation> ApplicantEducations { get; set; }
        public DbSet<ApplicantIdentity> ApplicantIdentities { get; set; }
        public DbSet<ApplicantOnlineTestAnswer> ApplicantOnlineTestAnswers { get; set; }
        public DbSet<ApplicantOnlineTestResult> ApplicantOnlineTestResults { get; set; }
        public DbSet<ApplicantPersonalData> ApplicantPersonalDatas { get; set; }
        public DbSet<ApplicantRecruitStep> ApplicantRecruitSteps { get; set; }
        public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkExperience> ApplicantWorkExperiences { get; set; }
        public DbSet<ApplicationApplicant> ApplicationApplicants { get; set; }
        public DbSet<ReasonStepFailed> ReasonStepFaileds { get; set; }
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

            #region [MASTER DATA]
            modelBuilder.ApplyConfiguration(new AdsCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AdsMediaConfiguration());
            modelBuilder.ApplyConfiguration(new JobCategoryConfiguration());
            #endregion

            #region [MASTER SETTING]
            modelBuilder.ApplyConfiguration(new OnlineTestSettingConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionSettingConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionSettingDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ScoringSettingConfiguration());
            modelBuilder.ApplyConfiguration(new ScoringSettingDetailConfiguration());
            #endregion

            #region [ORGANIZATION]
            modelBuilder.ApplyConfiguration(new JobLevelConfiguration());
            modelBuilder.ApplyConfiguration(new OrgLevelConfiguration());
            modelBuilder.ApplyConfiguration(new OrgStructureConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            #endregion

            #region [RECRUITMENT]
            modelBuilder.ApplyConfiguration(new MPPConfiguration());
            modelBuilder.ApplyConfiguration(new RequirementMasterConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitStepConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitStepGroupConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitStepGroupDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitmentReqStepConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitmentRequestConfiguration());
            modelBuilder.ApplyConfiguration(new RequirementRecRequestConfiguration());
            #endregion

            #region [APPLICANT]
            modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantAddressConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantEducationConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantIdentityConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantOnlineTestAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantOnlineTestResultConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantPersonalDataConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantRecruitStepConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantSkillConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantWorkExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new ReasonStepFailedConfiguration());
            #endregion
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
