using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Constants
{
    public static class TablePersonalInformation
    {
        #region [Prefix - TEPM]
        public const string CorePrefix = "TEPM";

        
        public const string Employee = CorePrefix + "Employee";
        public const string EmployeeCapColor = CorePrefix + "EmployeeCapColor";
        public const string EmployeePickUp = CorePrefix + "EmployeePickUp";
        public const string FamilyRelation = CorePrefix + "FamilyRelation";
        public const string GeotaggingAnywhere = CorePrefix + "GeotaggingAnywhere";
        public const string SuperiorSubordinate = CorePrefix + "SuperiorSubordinate";

        #endregion

        #region [Prefix - TEPD]
        public const string CorePrefixDetail = "TEPD";

        public const string CompetencyScore = CorePrefixDetail + "CompetencyScore";
        public const string EmployeeAddress = CorePrefixDetail + "EmployeeAddress";
        public const string EmployeeCareerHistory = CorePrefixDetail + "EmployeeCareerHistory";
        public const string EmployeeCustomField = CorePrefixDetail + "EmployeeCustomField";
        public const string EmployeeDocument = CorePrefixDetail + "EmployeeDocument";
        public const string EmployeeEducation = CorePrefixDetail + "EmployeeEducation";
        public const string EmployeeFamily = CorePrefixDetail + "EmployeeFamily";
        public const string EmployeeFamilyTaxStatus = CorePrefixDetail + "EmployeeFamilyTaxStatus";
        public const string EmployeeFamilyTaxStatusFUKURYO = CorePrefixDetail + "EmployeeFamilyTaxStatusFUKURYO";
        public const string EmployeeIdentity = CorePrefixDetail + "EmployeeIdentity";
        public const string EmployeeInventory = CorePrefixDetail + "EmployeeInventory";
        public const string EmployeeMedical = CorePrefixDetail + "EmployeeMedical";
        public const string EmployeePersonalData = CorePrefixDetail + "EmployeePersonalData";
        public const string EmployeePickupTransport = CorePrefixDetail + "EmployeePickupTransport";
        public const string EmployeePunishment = CorePrefixDetail + "EmployeePunishment";
        public const string EmployeeReward = CorePrefixDetail + "EmployeeReward";
        public const string EmployeeSetPickUp = CorePrefixDetail + "EmployeeSetPickUp";
        public const string EmployeeSetPickUpDetail = CorePrefixDetail + "EmployeeSetPickUpDetail";
        public const string EmployeeSetPickUpDetailBus = CorePrefixDetail + "EmployeeSetPickUpDetailBus";
        public const string EmployeeSkill = CorePrefixDetail + "EmployeeSkill";
        public const string EmployeeTraining = CorePrefixDetail + "EmployeeTraining";
        public const string EmployeeWorkingExperience = CorePrefixDetail + "EmployeeWorkingExperience";
        public const string EoCSurvey = CorePrefixDetail + "EoCSurvey";
        public const string TempEmployeeCareerHistory = CorePrefixDetail + "TempEmployeeCareerHistory";
        public const string TempEmployeeMedical = CorePrefixDetail + "TempEmployeeMedical";
        public const string WorkLocationAjinomoto = CorePrefixDetail + "WorkLocationAjinomoto";
        
        #endregion
    }

}
