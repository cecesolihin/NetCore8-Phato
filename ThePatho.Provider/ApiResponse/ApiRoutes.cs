
namespace ThePatho.Provider.ApiResponse
{
    public static class ApiRoutes
    {
        public const string BaseApiPathIdentity = "api/identity/";
        public const string BaseApiPathOrganization = "api/organization/";
        public const string BaseApiPathGlobal = "api/global/";
        public const string BaseApiPathPersonalInfo = "api/personal-info/";

        public static class IdentityMenu
        {
            public const string Authentication = BaseApiPathIdentity + "auth";
            public const string UserManagement = BaseApiPathIdentity + "user-management";
        }
      
        public static class OrganizationMenu
        {
            public const string CompanyBank = BaseApiPathOrganization + "company-bank";
            public const string CompanyProfile = BaseApiPathOrganization + "company-profile";
            public const string EmploymentType = BaseApiPathOrganization + "employment-type";
            public const string CostCenter = BaseApiPathOrganization + "cost-center";
            public const string Grade = BaseApiPathOrganization + "grade";
            public const string HistOrgStructure = BaseApiPathOrganization + "hist-org-structure";
            public const string Jabatan = BaseApiPathOrganization + "jabatan";
            public const string JobClass = BaseApiPathOrganization + "job-class";
            public const string JobLevel = BaseApiPathOrganization + "job-level";
            public const string JobLevelJobClass = BaseApiPathOrganization + "job-level-job-class";
            public const string MutationType = BaseApiPathOrganization + "mutation-type";
            public const string OrgLevel = BaseApiPathOrganization + "org-level";
            public const string OrgStructure = BaseApiPathOrganization + "org-structure";
            public const string PensionType = BaseApiPathOrganization + "pension-type";
            public const string Position = BaseApiPathOrganization + "position";
            public const string Rank = BaseApiPathOrganization + "rank";
            public const string ResignType = BaseApiPathOrganization + "resign-type";
            public const string TerminationType = BaseApiPathOrganization + "termination-type";
            public const string WorkLocation = BaseApiPathOrganization + "work-location";
            public const string WorkLocationGroup = BaseApiPathOrganization + "work-location-group";
        }
       
        public static class PersonalInfoMenu
        {
            
            public const string Employee = BaseApiPathPersonalInfo + "employee";
            public const string EmployeeAddress = BaseApiPathPersonalInfo + "employee-address";
            public const string EmployeeCapColor = BaseApiPathPersonalInfo + "employee-cap-color";
            public const string EmployeeCareerHistory = BaseApiPathPersonalInfo + "employee-career-history";
            public const string EmployeeCustomField = BaseApiPathPersonalInfo + "employee-custom-field";
            public const string EmployeeDocument = BaseApiPathPersonalInfo + "employee-document";
            public const string EmployeeEducation = BaseApiPathPersonalInfo + "employee-education";
            public const string EmployeeExperience = BaseApiPathPersonalInfo + "employee-experience";
            public const string EmployeeFamily = BaseApiPathPersonalInfo + "employee-family";
            public const string EmployeeIdentity = BaseApiPathPersonalInfo + "employee-identity";
            public const string EmployeeInventory = BaseApiPathPersonalInfo + "employee-inventory";
            public const string EmployeeMedical = BaseApiPathPersonalInfo + "employee-medical";
            public const string EmployeePersonalData = BaseApiPathPersonalInfo + "employee-personal-data";
            public const string EmployeePickUp = BaseApiPathPersonalInfo + "employee-pick-up";
            public const string EmployeePunishment = BaseApiPathPersonalInfo + "employee-punishment";
            public const string EmployeeReward = BaseApiPathPersonalInfo + "employee-reward";
            public const string EmployeeSetPickUp = BaseApiPathPersonalInfo + "employee-set-pick-up";
            public const string EmployeeSetPickUpDetail = BaseApiPathPersonalInfo + "employee-set-pick-up-detail";
            public const string EmployeeSkill = BaseApiPathPersonalInfo + "employee-skill";
            public const string EmployeeTraining = BaseApiPathPersonalInfo + "employee-training";
            public const string EmployeeWorkingExperience = BaseApiPathPersonalInfo + "employee-working-experience";
            public const string SuperiorSubordinate = BaseApiPathPersonalInfo + "superior-subordinate";
            
        }

        public static class GlobalMenu
        {
            public const string Announcement = BaseApiPathGlobal + "announcement";
            public const string BloodType = BaseApiPathGlobal + "blood-type";
            public const string BranchBank = BaseApiPathGlobal + "branch-bank";
            public const string Bank = BaseApiPathGlobal + "bank";
            public const string Building = BaseApiPathGlobal + "building";
            public const string City = BaseApiPathGlobal + "city";
            public const string ClothSize = BaseApiPathGlobal + "cloth-size";
            public const string Country = BaseApiPathGlobal + "country";
            public const string Currency = BaseApiPathGlobal + "currency";
            public const string GraduationType = BaseApiPathGlobal + "graduation-type";
            public const string Insurance = BaseApiPathGlobal + "insurance";
            public const string InventoryCondition = BaseApiPathGlobal + "inventory-condition";
            public const string InventoryType = BaseApiPathGlobal + "inventory-type";
            public const string LetterCategory = BaseApiPathGlobal + "letter-category";
            public const string LetterTemplate = BaseApiPathGlobal + "letter-template";
            public const string MaritalStatus = BaseApiPathGlobal + "marital-status";
            public const string MedicalGroup = BaseApiPathGlobal + "medical-group";
            public const string Nationality = BaseApiPathGlobal + "nationality";
            public const string NumericalSize = BaseApiPathGlobal + "numerical-size";
            public const string Province = BaseApiPathGlobal + "province";
            public const string PunishmentType = BaseApiPathGlobal + "punishment-type";
            public const string Religion = BaseApiPathGlobal + "religion";
            public const string ResignReason = BaseApiPathGlobal + "resign-reason";
            public const string RewardType = BaseApiPathGlobal + "reward-type";
            public const string RomanianSize = BaseApiPathGlobal + "romanian-size";
            public const string Room = BaseApiPathGlobal + "room";
            public const string ShoeSize = BaseApiPathGlobal + "shoe-size";
            public const string Skill = BaseApiPathGlobal + "skill";
            public const string SkillProficiency = BaseApiPathGlobal + "skill-proficiency";
            public const string TemplateKeyword = BaseApiPathGlobal + "template-keyword";
            public const string Course = BaseApiPathGlobal + "course";
            public const string DiseaseCategory = BaseApiPathGlobal + "disease-category";
            public const string EduLevel = BaseApiPathGlobal + "edu-level";
            public const string EduMajor = BaseApiPathGlobal + "edu-major";
            public const string FamilyRelation = BaseApiPathGlobal + "family-relation";
            public const string Identity = BaseApiPathGlobal + "identity";
            public const string InventoryGroup = BaseApiPathGlobal + "inventory-group";
            public const string InventoryGroupDetail = BaseApiPathGlobal + "inventory-group-detail";
            public const string InventoryGroupOrg = BaseApiPathGlobal + "inventory-group-org";
            public const string TaxStatus = BaseApiPathGlobal + "tax-status";
        }
        public static class Methods
        {
            #region [Authentication]
            public const string Login = "login";
            public const string Register = "register";
            public const string RefreshToken = "refresh-token";
            public const string ForgetPassword = "forget-password";
            public const string ResetPassword = "reset-password";
            public const string AssignUserGroup = "assign-user-group";
            public const string UserInfo = "user-info";
            #endregion

            #region [UserManagement]
            public const string GetUserList = "get-user-list";
            public const string GetSingleUser = "get-single-user";
            public const string GetUserByCriteria = "get-user-by-criteria";

            public const string GetRoleList = "get-role-list";
            public const string GetRoleByCriteria = "get-role-by-criteria";
            public const string GetSingleRole = "get-single-role";

            public const string GetGroupList = "get-group-list";
            public const string GetGroupByCriteria = "get-group-by-criteria";
            public const string GetSingleGroup = "get-single-group";

            public const string GetUserRoleList = "get-user-role-list";
            public const string GetUserRoleByCriteria = "get-user-role-by-criteria";

            public const string GetUserGroupList = "get-user-group-list";
            public const string GetUserGroupByCriteria = "get-user-group-by-criteria";
            #endregion
            #region [ALL]
            public const string GetList = "get-list";
            public const string GetSingle = "get-single";
            public const string GetByCriteria = "get-by-criteria";
            public const string GetDdl = "get-ddl";
            public const string Submit = "submit";
            public const string SubmitMulti = "submit-multi";
            public const string generate = "generate";
            public const string Delete = "delete";
            public const string Download = "download";
            #endregion
        }
    }
}
