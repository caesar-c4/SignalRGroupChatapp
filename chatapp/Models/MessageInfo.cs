using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chatapp.Models
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public string PostDateTime { get; set; }

        public string UserName { get; set; }
    }
}