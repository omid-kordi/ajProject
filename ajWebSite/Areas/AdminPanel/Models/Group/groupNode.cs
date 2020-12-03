using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Models.Group
{
    public class groupNode
    {
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public List<groupNode> children { get; set; } = new List<groupNode>();
    }
}
