using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Models.ticket
{
    public class ticketModel
    {

    }
    public class createNewTicketModel
    {
        public string title { get; set; }
        public int serverity { get; set; }
        public string description { get; set; }
        public List<string> messages { get; set; }
        public string emailAddress { get; set; }
    }
}
