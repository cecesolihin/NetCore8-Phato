﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.ConfigurationExtensions
{
    public static class ApiRoutes
    {
        public const string BaseApiPathMasterData = "api/master-data/";
        public const string BaseApiPathMasterSetting = "api/master-setting/";
        public const string BaseApiPathApplicant = "api/applicant/";
        public const string BaseApiPathRecruitment = "api/recruitment/";

        public static class MasterDataMenu
        {
            public const string AdsCategory = BaseApiPathMasterData + "ads-category";
            public const string AdsMedia = BaseApiPathMasterData + "ads-media";
            public const string JobCategory = BaseApiPathMasterData + "job-category";

        }
        public static class MasterSettingMenu
        {
            public const string QuestionSetting = BaseApiPathMasterSetting + "question-setting";
            public const string QuestionSettingDetail = BaseApiPathMasterSetting + "question-setting-detail";
            public const string OnlineTestSetting = BaseApiPathMasterSetting + "online-test-setting";
            public const string ScoringSetting = BaseApiPathMasterSetting + "scoring-setting";
            public const string ScoringSettingDetail = BaseApiPathMasterSetting + "scoring-setting-detail";
        }
        public static class RecruitmentMenu
        {
            public const string RecruitmentRequest = BaseApiPathRecruitment + "recruitment-request";
            public const string RecruitmentReqStep = BaseApiPathRecruitment + "recruitment-req-step";
            public const string RecruitStep = BaseApiPathRecruitment + "recruit-step";
            public const string RecruitStepGroup = BaseApiPathRecruitment + "recruit-step-group";
            public const string RecruitStepGroupDetail = BaseApiPathRecruitment + "recruit-step-group-detail";
            public const string RequirementRecRequest = BaseApiPathRecruitment + "recruitment-rec-request";
        }
        public static class ApplicantMenu
        {
            public const string Applicant = BaseApiPathApplicant + "applicant";
            public const string ApplicantAddress = BaseApiPathApplicant + "applicant-address";
            public const string ApplicantDocument = BaseApiPathApplicant + "applicant-document";
            public const string ApplicantEducation = BaseApiPathApplicant + "applicant-education";
            public const string ApplicantIdentity = BaseApiPathApplicant + "applicant-identity";
            public const string ApplicantSkill = BaseApiPathMasterData + "applicant-skill";
            public const string ApplicantWorkExperience = BaseApiPathApplicant + "applicant-work-experience";
            public const string ApplicantPersonalData = BaseApiPathApplicant + "applicant-personal-data";
            public const string ApplicantRecruitStep = BaseApiPathMasterData + "applicant-recruit-step";
            public const string ApplicantOnlineTestAnswer = BaseApiPathApplicant + "applicant-online-test-answer";
            public const string ApplicantOnlineTestResult = BaseApiPathApplicant + "applicant-online-test-result";
            public const string ApplicationApplicant = BaseApiPathApplicant + "application-applicant";
            public const string ReasonStepFailed = BaseApiPathMasterData + "reason-step-failed";
        }
        public static class Methods
        {
            public const string GetList = "get-list";
            public const string GetByCriteria = "get-by-criteria";
            public const string GetDdl = "get-ddl";
        }
    }
}