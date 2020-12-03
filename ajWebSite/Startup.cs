using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ajWebSite.Domain;
using ajWebSite.Core.Module;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using ajWebSite.Services.AutoMapperConfig;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Modules.Common;
using ajWebSite.Services.Modules.Security;
using ajWebSite.Services.Contracts.Security;
using ajWebSite.Core.DataAccess;
using ajWebSite.Services.Contracts.ajWebSite;
using ajWebSite.Services.Modules.ajWebSite;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace ajWebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddControllers().AddNewtonsoftJson();  
            services.AddDbContext<DB>(options => options
                .UseSqlServer(Configuration.GetConnectionString("dbconn")));
                            services.AddScoped<DbContext, DB>(); 
            services.AddAutoMapper(typeof(CommonProfile).Assembly);
            services.AddAutoMapper(typeof(ajWebSiteProfile).Assembly);

            Extensions.Mapper = services.BuildServiceProvider().GetService<IMapper>();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Secret").Value);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme);

            services.ConfigureApplicationCookie(o => o.LoginPath = "/AdminPanel/Auth/login");



            services.AddHttpContextAccessor();
            services.AddScoped<CurrentUser>();
            services.AddScoped<currentConfig>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ITextMessageBiz, TextMessageBiz>();



            //services.AddScoped<IUserBiz, UserBiz>();
            //services.AddScoped<IPersonBiz, PersonBiz>();
            //services.AddScoped<ILookupBiz, LookupBiz>();
            //services.AddScoped<IFileBinaryBiz, FileBinaryBiz>();
            //services.AddScoped<IParkingBiz, ParkingBiz>();
            //services.AddScoped<IticketBiz, TicketBiz>();
            //services.AddScoped<INewsAndItemBiz, NewsAndItemBiz>();
            //services.AddScoped<IGroupBiz, GroupBiz>();
            //services.AddScoped<ICommentBiz, CommentBiz>();
            //services.AddScoped<IVoteBiz, VoteBiz>();
            //services.AddScoped<IConfigBiz, ConfigBiz>();
            //services.AddScoped<IsalonBiz, salonBiz>();
            //services.AddScoped<IsurveyBiz, surveyBiz>();
            var allOfTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(p => p.GetTypes()).ToList();
            var TypeNames =
                allOfTypes.Where(p => p.Name.ToLower().StartsWith("i") &&
                (p.Assembly.FullName.ToLower().StartsWith("ajwebsite") || p.Assembly.FullName.ToLower().StartsWith("ajwebsite"))).ToList();
            foreach (Type interfaceModel in TypeNames)
            {
                if (interfaceModel.IsInterface == true)
                {
                    var businessTypeName = interfaceModel.Name.Substring(1);
                    var businessType = allOfTypes.FirstOrDefault(p => p.Name == businessTypeName);
                    if (businessType != null)
                    {
                        services.AddScoped(interfaceModel, businessType);
                    }
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
