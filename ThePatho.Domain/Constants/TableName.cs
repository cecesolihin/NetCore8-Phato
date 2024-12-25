using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Constants
{
    public static class TableName
    {
        //Identity
        public const string Users = "TUsers";
        public const string UserLogs = "TUserLog";
        public const string UserGroups = "TUserGroups";
        public const string Groups = "TGroups";
        public const string GroupRoles = "TGroupRoles";
        public const string Roles = "TRoles";
        //Master Data
        public const string Category = "TTRMCategory";
        public const string AdsCategory = "TMAdsCategory";
        public const string AdsMedia = "TMAdsMedia";
        public const string JobCategory = "TMJobCategory";
        //Master Setting
        public const string OnlineTestSetting = "TMOnlineTestSetting";
        public const string QuestionSetting = "TMQuestionSetting";
        public const string QuestionSettingDetail = "TMQuestionSettingDetail";
        public const string ScoringSetting = "TMScoringSetting";
        public const string ScoringSettingDetail = "TMScoringSettingDetail";
        //Recruitment
        public const string RecruitStep = "TMRecruitStep";
        public const string RecruitStepGroup = "TMRecruitStepGroup";
        public const string RecruitStepGroupDetail = "TMRecruitStepGroupDetail";
        public const string RecruitmentReqStep = "TRRecruitmentReqStep";
        public const string RecruitmentRequest = "TRRecruitmentRequest";
        public const string RequirementRecRequest = "TRRequirementRecRequest";
        //Applicant
        public const string Applicant = "TMApplicant";
        public const string ApplicantAddress = "TRApplicantAddress";
        public const string ApplicantDocument = "TRApplicantDocument";
        public const string ApplicantEducation = "TRApplicantEducation";
        public const string ApplicantIdentity = "TRApplicantIdentity";
        public const string ApplicantOnlineTestAnswer = "TRApplicantOnlineTestAnswer";
        public const string ApplicantOnlineTestResult = "TRApplicantOnlineTestResult";
        public const string ApplicantPersonalData = "TRApplicantPersonalData";
        public const string ApplicantRecruitStep = "TRApplicantRecruitStep";
        public const string ApplicantSkill = "TRApplicantSkill";
        public const string ApplicantWorkExperience = "TRApplicantWorkExperience";
        public const string ApplicationApplicant = "TRApplicationApplicant";
        public const string ReasonStepFailed = "TRReasonStepFailed";
        
    }
}
