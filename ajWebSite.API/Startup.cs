using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ajWebSite.API.Modules;
using ajWebSite.Common.Configuration;
using ajWebSite.Core.DataAccess; 
using ajWebSite.Core.Module;
using ajWebSite.Domain;
using ajWebSite.Services.AutoMapperConfig;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.Security;
using ajWebSite.Services.Modules.Common;
using ajWebSite.Services.Modules.Security;

namespace ajWebSite.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        /*.AllowCredentials()*/);
            });
            services.AddControllers().AddNewtonsoftJson();

            var sepConfig = Configuration
                .GetSection("SepPaymentConfiguration")
                .Get<SepPaymentConfiguration>();
            services.AddSingleton(sepConfig);

#if DEBUG
            services.AddDbContext<DB>(options =>options
            .UseSqlServer(Configuration.GetConnectionString("dbconn")));
            services.AddScoped<DbContext, DB>();
#else
            services.AddDbContext<DBOrcl>(options => options
                .UseOracle(Configuration.GetConnectionString("dbconnOrcl"),
                    opt => opt.UseOracleSQLCompatibility("11")));
                    //"User Id=auction;Password=auction_bg104;Data Source= (DESCRIPTION =     (ADDRESS = (PROTOCOL = TCP)(HOST = ajWebSitedbscan.ajWebSite.net)(PORT = 7811))     (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = ajWebSitedb.ajWebSite.net))   )"));
            services.AddScoped<DbContext, DBOrcl>();
#endif
            services.AddAutoMapper(typeof(CommonProfile).Assembly);

            Extensions.Mapper = services.BuildServiceProvider().GetService<IMapper>();


            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Secret").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddHttpContextAccessor();
            services.AddScoped<CurrentUser>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITextMessageBiz, TextMessageBiz>();


            services.AddScoped<IUserBiz, UserBiz>();
            services.AddScoped<IPersonBiz, PersonBiz>();
            services.AddScoped<ILookupBiz, LookupBiz>();
            services.AddScoped<IFileBinaryBiz, FileBinaryBiz>();
            services.AddScoped<IParkingBiz, ParkingBiz>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
//#if !DEBUG
            app.ConfigureExceptionHandler(/*logger*/);
//#endif
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
