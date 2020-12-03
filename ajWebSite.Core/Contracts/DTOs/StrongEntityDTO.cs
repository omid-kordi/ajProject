using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Core.Contracts.DTOs
{
	public abstract class  StrongEntityDTO : BaseEntityDTO
    {
        public int Id { get; set; }
	}
}
