using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chatapp.Models
{
    public class ChatUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginTime { get; set; }
        public string ConnectionId { get; set; }

        //public Boolean Connected { get; set; }

        public virtual ICollection<MessageInfo> MessageInfos { get; set; }
    }
}