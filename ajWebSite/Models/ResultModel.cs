using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Models
{
    public class ResultModel
    {
        public bool success { get; set; }
        public int resultTypeId { get; set; }
        public string resultMessage { get; set; }
        public object data
        {
            get;
            set;
        }
    }
}
