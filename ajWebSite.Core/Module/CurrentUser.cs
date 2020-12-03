using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;


namespace ajWebSite.Core.Module
{

    public static class CustomClaim
    {
        public const string PersonId = "PersonId";
        public const string CompanyId = "CompanyId";
        public const string userType = "userType";
    }
    public class CurrentUser
    {


        private IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Initialize();
        }
        public void Initialize()
        {
            if (this._httpContextAccessor.HttpContext?.User != null)
            {
                var user = this._httpContextAccessor.HttpContext.User;
                IsAuthenticated = user.Identity.IsAuthenticated;
                if (IsAuthenticated)
                { 
                    _username = user.Identity.Name;
                    //var user = identity as ClaimsIdentity;
                    _claims = user.Claims.ToList();
                    _id = int.Parse(_claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);
                    _personId = int.Parse(_claims.SingleOrDefault(x => x.Type == CustomClaim.PersonId)?.Value ?? "0");
                    _name = _claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;

                    _companyId = int.Parse((_claims.SingleOrDefault(x => x.Type == CustomClaim.CompanyId)?.Value ?? "0").Length==0?"0": _claims.SingleOrDefault(x => x.Type == CustomClaim.CompanyId)?.Value ?? "0");


                    //var tenant = _claims.SingleOrDefault(x => x.Type == "TENANT_ID");
                    //if (tenant != null)
                    //    _tenantId = int.Parse(tenant.Value);

                    _taskManager = new TaskManager(_id);
                }

            }

        }

        private List<Claim> _claims;
        private string _username;
        private string _name;

        private int _id;
        private int _tenantId;
        private int _companyId;
        private int _personId;
        private TaskManager _taskManager;
        public bool IsAuthenticated { get; private set; }

        public string DisplayName
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _name;

            }
        }
        public int CompanyId
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _companyId;

            }
        }
        public int ID
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _id;
            }
        }

        public int PersonId
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _personId;
            }
        }


        public string Username
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _username;
            }
        }


        public TaskManager TaskManager
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();

                return _taskManager;
            }
        }

        
        public string[] Roles
        {
            get
            {
                if (!IsAuthenticated)
                    Initialize();
                return _claims.Where(x => x.Type == ClaimTypes.Role).Select(s => s.Value).ToArray();
            }

        }

        
    }
}
