using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Constants
{
    public static class TableOrganization
    {
        #region [Prefix - TOGM]
        public const string CorePrefix = "TOGM";

        public const string CompanyProfile = CorePrefix + "CompanyProfile";
        public const string EmploymentType = CorePrefix + "EmploymentType";
        public const string Grade = CorePrefix + "Grade";
        public const string HistOrgStructure = CorePrefix + "HistOrgStructure";
        public const string Jabatan = CorePrefix + "Jabatan";
        public const string JobClass = CorePrefix + "JobClass";
        public const string JobLevel = CorePrefix + "JobLevel";
        public const string JobLevelJobClass = CorePrefix + "JobLevelJobClass";
        public const string MutationType = CorePrefix + "MutationType";
        public const string OrgLevel = CorePrefix + "OrgLevel";
        public const string OrgStructure = CorePrefix + "OrgStructure";
        public const string PensionType = CorePrefix + "PensionType";
        public const string Position = CorePrefix + "Position";
        public const string PositionHistoryPATRA = CorePrefix + "PositionHistoryPATRA";
        public const string Rank = CorePrefix + "Rank";
        public const string ResignType = CorePrefix + "ResignType";
        public const string SignatureReport = CorePrefix + "SignatureReport";
        public const string TerminationType = CorePrefix + "TerminationType";
        public const string WorkLocation = CorePrefix + "WorkLocation";
        public const string WorkLocationGroup = CorePrefixDetail + "WorkLocationGroup";
        public const string CostCenter = CorePrefix + "CostCenter";
        #endregion

        #region [Prefix - TOGM]
        public const string CorePrefixDetail = "TOGD";

        public const string CompanyBank = CorePrefixDetail + "CompanyBank";
        public const string WorkLocationGroupDetail = CorePrefixDetail + "WorkLocationGroup";
        #endregion
    }
}
