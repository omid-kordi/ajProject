using System;
using System.Collections.Generic;
using System.Text;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Domain.Common
{
    public class Parking : StrongEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }

        public Lookup Type { get; set; }
    }
}
