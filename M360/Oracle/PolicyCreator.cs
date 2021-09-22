using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JLTA.Common.Core.DataAccess;
using M360TestAutomation.Oracle;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace M360TestAutomation
{
    public class PolicyCreator
    {
        public readonly string CREATE_POLICY_STORED_PROC = "jbs_create_test_data.CreatePolicy";

        private OracleConnection _overriddenConnection = null;
        private OracleConnection Connection => _overriddenConnection ?? OracleDB.GetConnection();

        public PolicyCreator(OracleConnection connection = null)
        {
            if (connection != null) _overriddenConnection = connection;
        }

        public bool CreatePolicy(PolicyData data, out PolicyMetaData policyMetaData, out List<string> errors)
        {
            bool success;
            using (OracleCommand command = new OracleCommand(CREATE_POLICY_STORED_PROC, Connection))
            {
                // Setup Output Parameters
                var errorListParameter = new OracleParameter()
                {
                    ParameterName = "p_error_list",
                    OracleDbType = OracleDbType.Array,
                    Direction = ParameterDirection.Output,
                    UdtTypeName = TypeVarchar2_4kNtSet.TYPE_VARCHAR2_4K_NT
                };
                var policyIdParameter = new OracleParameter("policy_id", OracleDbType.Decimal, ParameterDirection.Output);
                var policyVersionIdParameter = new OracleParameter("policy_version_id", OracleDbType.Decimal, ParameterDirection.Output);
                var policyNumberParameter = new OracleParameter("p_policy_number", OracleDbType.Decimal, ParameterDirection.Output);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(new [] {
                    new OracleParameter("p_branch", OracleDbType.Varchar2, data.branch, ParameterDirection.Input),
                    new OracleParameter("p_team", OracleDbType.Varchar2, data.team, ParameterDirection.Input),
                    new OracleParameter("p_client", OracleDbType.Varchar2, data.client, ParameterDirection.Input),
                    new OracleParameter("p_market_segment", OracleDbType.Varchar2, data.marketSegment, ParameterDirection.Input),
                    new OracleParameter("p_insurance_class", OracleDbType.Varchar2, data.insuranceClass, ParameterDirection.Input),
                    
                    new OracleParameter()
                    {
                        ParameterName = "p_underwriters", 
                        OracleDbType = OracleDbType.Array, 
                        Direction = ParameterDirection.Input,
                        UdtTypeName = TypeVarchar2_100NtSet.TYPE_VARCHAR2_100_NT,
                        Value = data.underwriters.ToArray()
                    },
                    new OracleParameter()
                    {
                        ParameterName = "p_locations", 
                        OracleDbType = OracleDbType.Array,
                        Direction = ParameterDirection.Input,
                        UdtTypeName = TypeVarchar2_100NtSet.TYPE_VARCHAR2_100_NT,
                        Value = data.locations.ToArray()
                    },
                    
                    new OracleParameter("p_max_liability", OracleDbType.Decimal, data.maxLiability, ParameterDirection.Input),
                    new OracleParameter("p_situation_text", OracleDbType.Varchar2, data.situationText, ParameterDirection.Input),
                    new OracleParameter("p_from_date", OracleDbType.Date, data.fromDate, ParameterDirection.Input),
                    new OracleParameter("p_to_date", OracleDbType.Date, data.toDate, ParameterDirection.Input),
                    new OracleParameter("p_schedule_text", OracleDbType.Clob, data.scheduleText, ParameterDirection.Input),
                    new OracleParameter("p_broker_1_username", OracleDbType.Varchar2, data.broker1Username, ParameterDirection.Input),
                    
                    // Include Output Parameters
                    errorListParameter,
                    policyIdParameter,
                    policyVersionIdParameter,
                    policyNumberParameter
                });
                
                command.ExecuteNonQuery();
                var errorSet = errorListParameter.Value as TypeVarchar2_4kNtSet;
                errors = errorSet?.Value.ToList() ?? new List<string>();
                success = !errors.Any();
                if (success)
                {
                    policyMetaData = new PolicyMetaData((policyIdParameter.Value as OracleDecimal?)?.Value ?? 0, 
                                                        (policyVersionIdParameter.Value as OracleDecimal?)?.Value ?? 0,
                                                        (policyNumberParameter.Value as OracleDecimal?)?.Value ?? 0);
                }
                else
                {
                    policyMetaData = null;
                }
            
            }
            return success;
        }
    }

    public struct PolicyData
    {
        public string branch;
        public string team;
        public string client;
        public string marketSegment;
        public string insuranceClass;
        public List<string> underwriters;
        public List<string> locations;
        public decimal maxLiability;
        public string situationText;
        public DateTime fromDate;
        public DateTime toDate;
        public string scheduleText;
        public string broker1Username;

        public bool IsFullyPopulated() =>
            !(new[] {branch, team, client, marketSegment, insuranceClass, scheduleText}.Any(string.IsNullOrWhiteSpace))
            && (underwriters.Any() && locations.Any())
            ;

        public string AsJson()
        {
            return JObject.FromObject(this).ToString();
        }

        public string PrettyPrint(string indent="")
        {
            var builder = new StringBuilder();
            builder.AppendLine(indent + $"branch = {branch}");
            builder.AppendLine(indent + $"team = {team}");
            builder.AppendLine(indent + $"client = {client}");
            builder.AppendLine(indent + $"marketSegment = {marketSegment}");
            builder.AppendLine(indent + $"insuranceClass = {insuranceClass}");
            builder.AppendLine(indent + $"underwriters = {string.Join(", ", underwriters)}");
            builder.AppendLine(indent + $"locations = {string.Join(", ", locations)}");
            builder.AppendLine(indent + $"maxLiability = {maxLiability}");
            builder.AppendLine(indent + $"situationText = {situationText}");
            builder.AppendLine(indent + $"fromDate = {fromDate.ToShortDateString()}");
            builder.AppendLine(indent + $"toDate = {toDate.ToShortDateString()}");
            builder.AppendLine(indent + $"scheduleText = {scheduleText}");
            builder.AppendLine(indent + $"broker1Username = {broker1Username}");
            return builder.ToString();
        }
    }

    public class PolicyMetaData
    {
        public decimal? PolicyId { get; }
        public decimal? PolicyVersionId { get; }
        public decimal? PolicyNumber { get; }
        public PolicyMetaData(decimal policyId, decimal policyVersionId, decimal policyNumber)
        {
            PolicyId = policyId;
            PolicyVersionId = policyVersionId;
            PolicyNumber = policyNumber;
        }
    }
}
