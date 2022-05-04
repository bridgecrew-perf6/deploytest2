using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace TestProject.Engine
{
    public class CommonAction
    {
        private Database kboDB = EnterpriseLibraryContainer.Current.GetInstance<Database>("kbo_db2");

        /// <summary>
        /// 참고
        /// </summary>
        public JObject GetTest(string leId, string seasonId)
        {
            JObject result = new JObject();
            try
            {
                DbCommand cmd = kboDB.GetStoredProcCommand("PROC_KBO_DB2_PLAYER_LE_SEASON_TOP5");
                kboDB.AddInParameter(cmd, "@LE_ID", DbType.Int16, leId);
                kboDB.AddInParameter(cmd, "@SEASON_ID", DbType.Int16, seasonId);

                DataSet dsData = kboDB.ExecuteDataSet(cmd);

                DataRow[] drData = dsData.Tables[0].Select();

                JArray list = new JArray();

                foreach(DataRow item in drData)
                {
                    JObject obj = new JObject();
                    obj.Add(new JProperty("SEASON_ID", item["SEASON_ID"]));
                    obj.Add(new JProperty("P_NM", item["P_NM"]));
                    obj.Add(new JProperty("T_ID", item["T_ID"]));
                    list.Add(obj);
                }

                result.Add(new JProperty("list", list));
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}