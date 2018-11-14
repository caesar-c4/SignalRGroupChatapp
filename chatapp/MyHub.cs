using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using chatapp.Models;

namespace chatapp
{
    public class MyHub : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        

        public void Send(string msg)
        {
            string gName = db.RequestInfos.Where(u => u.UserName.Equals(Context.User.Identity.Name)).SingleOrDefault().GroupName;
            var messInfo = new MessageInfo
            {
                UserName = Context.User.Identity.Name,
                MessageBody = msg,
                PostDateTime = DateTime.Now.ToString()
            };
            db.MessageInfos.Add(messInfo);
            var type = "str";


            if (db.SaveChanges() > 0)
            {
                Groups.Add(Context.ConnectionId, gName);
                Clients.OthersInGroup(gName).Received(messInfo.UserName, msg, type);
                //Clients.OthersInGroup(gName).Received(messInfo.UserName, msg);

                Clients.Caller.Received("You", msg,type);
            }

        }
    }
}