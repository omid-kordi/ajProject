using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace ajWebSite.Core.Contracts.Entities
{
	public abstract class BaseEntity //: IEntity
    {
	    public BaseEntity()
	    {
            DateInserted = DateTime.Now;
            //UId = Guid.NewGuid();
	    }
        //[Index]
        //public Guid? UId { get; set; }
        public int? CreatorId { get; set; } 
        public DateTime DateInserted { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UpdaterId { get; set; }

        public bool IsDelete { get; set; }

        //public int? TenantId { get; set; }

    }
}