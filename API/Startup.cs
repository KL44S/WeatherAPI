﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Business.Factories.Absctractions;
using Business.Factories.Implementations;
using Business.Mappers.Abstractions;
using Business.Mappers.Implementations;
using Business.Services.Abstractions;
using Business.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Dependency Injection
            services.AddHttpContextAccessor();

            //Services
            services.AddScoped<IGenericRestService, GenericRestService>();
            services.AddScoped<ILocationFinder, LocationFinder>();
            services.AddScoped<IWeatherStateService, WeatherStateService>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IWeatherService, WeatherService>();

            //Mappers
            services.AddScoped<IKeyCDNGeoIpLocationMapper, KeyCDNGeoIpLocationMapper>();
            services.AddScoped<IOpenWeatherMapper, OpenWeatherMapper>();
            services.AddScoped<IWorldTimeMapper, WorldTimeMapper>();

            //Factories
            services.AddScoped<IDayTimeServiceFactory, DayTimeServiceFactory>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
