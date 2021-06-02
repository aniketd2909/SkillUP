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
using Microsoft.OpenApi.Models;
using PreLearningBackend.Context;
using PreLearningBackend.JWTAuthenticationManager;
using PreLearningBackend.Services.Blocker;
using PreLearningBackend.Services.ExpereienceFeed;
using PreLearningBackend.Services.Practice;
using PreLearningBackend.Services.Resource;
using PreLearningBackend.Services.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreLearningBackend
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
            services.AddCors();

            services.AddMvc();

            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IBestPracticesService, BestPracticesService>();
            services.AddScoped<IProblemStatementService, ProblemStatementService>();
            services.AddScoped<IMcqService, McqService>();
            services.AddScoped<IExperienceFeedService, ExperienceFeedService>();


            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            string mySqlConnectionStr = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            // services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICampusMindRegisterService, CampusMindRegisterService>();
            services.AddScoped<IMindTreeMindRegisterService, MindTreeMindRegisterService>();
            services.AddScoped<ISelectedUserService, SelectedUserService>();
            services.AddScoped<IRoleService, RoleService>();
            //   services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBlockerService, BlockerService>();
            services.AddScoped<IBlockerSolutionService, BlockerSolutionService>();
            services.AddScoped<IJWTAuthentication, JWTAuthentication>();

            services.AddControllers();
           // var key = "This is my long private SecretKey";
            services.AddAuthentication(x =>
                  {
                      x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                      x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                  }).AddJwtBearer(x =>
                  {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
          //  services.AddSingleton<IJWTAuthentication>(new JWTAuthentication(key));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PreLearningBackend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PreLearningBackend v1"));
            }

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
