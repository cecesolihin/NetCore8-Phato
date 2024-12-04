using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
using ThePatho.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SqlQueryLoader>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAdsCategoryService, AdsCategoryService>();
builder.Services.AddScoped<IAdsMediaService, AdsMediaService>();
builder.Services.AddScoped<IJobCategoryService, JobCategoryService>();
builder.Services.AddScoped<IOnlineTestSettingService, OnlineTestSettingService>();
builder.Services.AddScoped<IQuestionSettingService, QuestionSettingService>();
builder.Services.AddScoped<IQuestionSettingDetailService, QuestionSettingDetailService>();
builder.Services.AddScoped<IScoringSettingService, ScoringSettingService>();
builder.Services.AddScoped<IScoringSettingDetailService, ScoringSettingDetailService>();
builder.Services.AddScoped<IRecruitStepService, RecruitStepService>();
builder.Services.AddScoped<IRecruitStepGroupService, RecruitStepGroupService>();
builder.Services.AddScoped<IRecruitStepGroupDetailService, RecruitStepGroupDetailService>();
builder.Services.AddScoped<IRecruitmentReqStepService, RecruitmentReqStepService>();
builder.Services.AddScoped<IRecruitmentRequestService, RecruitmentRequestService>();
builder.Services.AddScoped<IRequirementRecRequestService, RequirementRecRequestService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IApplicantAddressService, ApplicantAddressService>();
builder.Services.AddScoped<IApplicantDocumentService, ApplicantDocumentService>();
builder.Services.AddScoped<IApplicantEducationService, ApplicantEducationService>();
builder.Services.AddScoped<IApplicantIdentityService, ApplicantIdentityService>();
builder.Services.AddScoped<IApplicantOnlineTestAnswerService, ApplicantOnlineTestAnswerService>();
builder.Services.AddScoped<IApplicantOnlineTestResultService, ApplicantOnlineTestResultService>();
builder.Services.AddScoped<IApplicantPersonalDataService, ApplicantPersonalDataService>();
builder.Services.AddScoped<IApplicantRecruitStepService, ApplicantRecruitStepService>();
builder.Services.AddScoped<IApplicantSkillService, ApplicantSkillService>();
builder.Services.AddScoped<IApplicantWorkExperienceService, ApplicantWorkExperienceService>();
builder.Services.AddScoped<IApplicationApplicantService, ApplicationApplicantService>();
builder.Services.AddScoped<IReasonStepFailedService, ReasonStepFailedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
