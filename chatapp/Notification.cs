using chatapp.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace chatapp
{
    public class Notification
    {
        public void StudentRegister(DateTime date)
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = @"Select GroupName,UserName,Approved from [dbo].RequestInfoes where ReqDateTime>@dat ";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@dat", date);
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            SqlDependency sd = new SqlDependency(cmd);
            sd.OnChange += sd_OnChange;

            SqlDataReader reader = cmd.ExecuteReader();
        }

        void sd_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sd = sender as SqlDependency;
                sd.OnChange -= sd_OnChange;
                var myHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                myHub.Clients.All.message("newrecord");
            }
        }
        public List<RequestInfo> Getstudents(DateTime adate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var lst = db.RequestInfos.Where(s => s.ReqDateTime > adate && s.Approved.Equals(false)).OrderByDescending(a => a.Id).ToList();
                return lst;
            }

        }
    }
}