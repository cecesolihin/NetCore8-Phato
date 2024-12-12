using Microsoft.Extensions.DependencyInjection;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Features.Applicant.ApplicantDocument.Service;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Features.Applicant.ApplicantIdentity.Service;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.Applicant.ApplicantWorkExperience.Service;
using ThePatho.Features.Applicant.ApplicationApplicant.Service;
using ThePatho.Features.Applicant.ReasonStepFailed.Service;
using ThePatho.Features.Category.Service;
using ThePatho.Features.MasterData.AdsCategory.Service;
using ThePatho.Features.MasterData.AdsMedia.Service;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;
using ThePatho.Features.MasterSetting.ScoringSetting.Service;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;
using ThePatho.Features.Recruitment.RecruitStep.Service;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;
using ThePatho.Features.Recruitment.RequirementRecRequest.Service;

public static class ServiceRegistrationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAdsCategoryService, AdsCategoryService>();
        services.AddScoped<IAdsMediaService, AdsMediaService>();
        services.AddScoped<IJobCategoryService, JobCategoryService>();
        services.AddScoped<IOnlineTestSettingService, OnlineTestSettingService>();
        services.AddScoped<IQuestionSettingService, QuestionSettingService>();
        services.AddScoped<IQuestionSettingDetailService, QuestionSettingDetailService>();
        services.AddScoped<IScoringSettingService, ScoringSettingService>();
        services.AddScoped<IScoringSettingDetailService, ScoringSettingDetailService>();
        services.AddScoped<IRecruitStepService, RecruitStepService>();
        services.AddScoped<IRecruitStepGroupService, RecruitStepGroupService>();
        services.AddScoped<IRecruitStepGroupDetailService, RecruitStepGroupDetailService>();
        services.AddScoped<IRecruitmentReqStepService, RecruitmentReqStepService>();
        services.AddScoped<IRecruitmentRequestService, RecruitmentRequestService>();
        services.AddScoped<IRequirementRecRequestService, RequirementRecRequestService>();
        services.AddScoped<IApplicantService, ApplicantService>();
        services.AddScoped<IApplicantAddressService, ApplicantAddressService>();
        services.AddScoped<IApplicantDocumentService, ApplicantDocumentService>();
        services.AddScoped<IApplicantEducationService, ApplicantEducationService>();
        services.AddScoped<IApplicantIdentityService, ApplicantIdentityService>();
        services.AddScoped<IApplicantOnlineTestAnswerService, ApplicantOnlineTestAnswerService>();
        services.AddScoped<IApplicantOnlineTestResultService, ApplicantOnlineTestResultService>();
        services.AddScoped<IApplicantPersonalDataService, ApplicantPersonalDataService>();
        services.AddScoped<IApplicantRecruitStepService, ApplicantRecruitStepService>();
        services.AddScoped<IApplicantSkillService, ApplicantSkillService>();
        services.AddScoped<IApplicantWorkExperienceService, ApplicantWorkExperienceService>();
        services.AddScoped<IApplicationApplicantService, ApplicationApplicantService>();
        services.AddScoped<IReasonStepFailedService, ReasonStepFailedService>();
    }
}
