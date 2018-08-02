using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Dapper;
using Dapper.FastCrud;
using DigitalHajj.Models;

namespace DigitalHajj.DataAccess
{
    public class StatusReport
    {
        private IDbConnection DbConnection;

        public StatusReport(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public IEnumerable<CameraStatus> GetAirportStatus(int airport_id)
        {
            var parms = new DynamicParameters();
            parms.Add("@Airport", airport_id);
            //parms.Add("@ToDate", searchPolicyCriteria.ToDate.HasValue ? (object)searchPolicyCriteria.ToDate : null);
            //parms.Add("@Passport", string.IsNullOrEmpty(searchPolicyCriteria.Passport) == false ? (object)searchPolicyCriteria.Passport : null);
            //parms.Add("@PolicyNumber", string.IsNullOrEmpty(searchPolicyCriteria.PolicyNumber) == false ? (object)searchPolicyCriteria.PolicyNumber : null);
            //parms.Add("@Status", searchPolicyCriteria.Status.HasValue ? (object)searchPolicyCriteria.Status : null);
            //return DbConnection.Query<SearchPolicyResult>("SearchPolicies", parms, commandType: CommandType.StoredProcedure).ToList();
            return DbConnection.Query<CameraStatus>("SELECT rule_name,Count(1) as total  FROM[HAJ].[dbo].[CameraEvent]   where camera_id in (select camera_id from camera where airport_id = @Airport)  group by rule_name ", parms);
        }
    }
}
