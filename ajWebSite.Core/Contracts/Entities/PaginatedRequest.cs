using System.Collections.Generic;
//using Kendo.DynamicLinq;

namespace ajWebSite.Core.Contracts.Entities
{
	public class PaginatedRequest
	{
	    public PaginatedRequest()
	    {
            //Sort = new List<Sort>();
	        Page = 1;
	        PageSize = 10;
	    }
        //public int Offset
        //{
        //    get { return (this.PageNumber) * this.PageSize;  }
        //}
        //public int Limit
        //{
        //    get { return this.PageSize; }
        //}
	    public int Skip => (Page - 1) * PageSize;

        public int Take => PageSize;

	    private string _sort;

	    public string Sort
	    {
	        get => _sort?.Replace("-", " ");
	        set => _sort = value;
	    }

	    public bool HasSort => _sort != null;

	    public int Page { get; set; }

	    public int PageSize { get; set; }
	    //public string SortField { get; set; }

	    //public string SortOrder { get; set; }
	    //public IList<Sort> Sort { get; set; }
	    ////[DataMember(Name = "filter")]
	    //public Filter Filter { get; set; }
	}
}
