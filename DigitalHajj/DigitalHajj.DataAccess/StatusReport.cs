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
            return DbConnection.Query<CameraStatus>("SELECT rule_name,Count(1) as total  FROM[HAJ].[dbo].[CameraEvent]   where camera_id in (select camera_id from camera where airport_id = @Airport)  group by rule_name ", parms);
        }
        public IEnumerable<CameraStatus> GetAirportStatus(int airport_id,DateTime time)
        {
            var parms = new DynamicParameters();
            parms.Add("@Airport", airport_id);
            parms.Add("@CalculateTime", time);
            return DbConnection.Query<CameraStatus>("SELECT rule_name,Count(1) as total  FROM[HAJ].[dbo].[CameraEvent]   where camera_id in (select camera_id from camera where airport_id = @Airport) And time <= @CalculateTime  group by rule_name ", parms);
        }
        public IEnumerable<CameraStatus> GetHallStatus(int airport , int hall_id)
        {
            var parms = new DynamicParameters();
            parms.Add("@HallId", hall_id);
            parms.Add("@Airport", airport);
            return DbConnection.Query<CameraStatus>("SELECT rule_name,Count(1) as total  FROM[HAJ].[dbo].[CameraEvent]   where camera_id in (select camera_id from camera where halltype_id = @HallId and airport_id = @Airport)  group by rule_name ", parms);
        }
        public IEnumerable<CameraStatus> GetHallStatus(int airport, int hall_id,DateTime time)
        {
            var parms = new DynamicParameters();
            parms.Add("@HallId", hall_id);
            parms.Add("@Airport", airport);
            parms.Add("@CalculateTime", time);
            return DbConnection.Query<CameraStatus>("SELECT rule_name,Count(1) as total  FROM[HAJ].[dbo].[CameraEvent]   where camera_id in (select camera_id from camera where halltype_id = @HallId and airport_id = @Airport) And time <= @CalculateTime  group by rule_name ", parms);
        }
    }
}
