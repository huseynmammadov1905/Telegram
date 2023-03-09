using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram__
{
    public class Message
    {
        public Message() { }

        public Message(string name, bool youOrUser, string time, string message)
        {
            this.name = name;
            this.youOrUser = youOrUser;
            this.message = message;
            Time = time;
        }

        public string name { get; set; }
        public bool youOrUser { get; set; }
        public string message { get; set; }

        public string Time { get; set; }
    }
}
