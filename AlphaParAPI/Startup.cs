using System;
using System.Security.Principal;
using System.Text;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlphaParAPI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins()
                                  .AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
            });
          
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddAuthentication(IISDefaults.AuthenticationScheme);
            // services.AddAuthentication().AddMicrosoftAccount();

            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AlphaParDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowSpecificOrigin");
            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseMvc();
            app.Run(async (context) =>
            {
                try
                {
                    var user = (WindowsIdentity)context.User.Identity;

                    await context.Response
                                 .WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");

                    WindowsIdentity.RunImpersonated(user.AccessToken, () =>
                    {
                        var impersonatedUser = WindowsIdentity.GetCurrent();
                        var message =
                            $"User: {impersonatedUser.Name}\tState: {impersonatedUser.ImpersonationLevel}";

                        var bytes = Encoding.UTF8.GetBytes(message);
                        context.Response.Body.Write(bytes, 0, bytes.Length);
                    });
                }
                catch (Exception e)
                {
                    await context.Response.WriteAsync(e.ToString());
                }
            });
        }
    }
}