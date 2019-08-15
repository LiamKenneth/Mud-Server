﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArchaicQuestII.Engine.Character.Class.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ArchaicQuestII.Hubs;
using Serilog;
using ArchaicQuestII.Core.Events;
using ArchaicQuestII.Engine.Core.Events;
using ArchaicQuestII.Engine.Spell.Interface;
using ArchaicQuestII.Log;

namespace ArchaicQuestII
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
            var writeToClient = new WriteToClient();
            services.AddSingleton<ILog>(new Log.Log());
          services.AddSingleton<IWriteToClient>(writeToClient);
            services.AddMvc();
            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Play/Error");
            }

            app.UseStaticFiles();

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
      
            app.UseMvc(routes =>
            {
              
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Play}/{action=Index}/{id?}");

            });

    
            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/Hubs/game");
            });

            var seedClass = new SeedClassCommand();
            var seedRace = new SeedRaceCommand();
            var seedAttackType = new SeedAttackTypesCommand();
            var seedStatusese = new SeedStatusCommand();
            var seedAlignment = new SeedAlignmentCommand();

            seedAttackType.Seed();
            seedClass.SeedClass();
            seedRace.Seed();
            seedStatusese.Seed();
            seedAlignment.Seed();
        }
    }
}
