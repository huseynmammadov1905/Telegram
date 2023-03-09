using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram__
{
    public class Person
    {
        public int Id { get; set; }
        public string Avatar { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }
        public string Time { get; set; }

        public List<Message> userContacts { get; set; }
        public Person() { }
    }
}
