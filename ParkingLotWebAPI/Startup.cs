using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using ParkingLotCore;
using ParkingLotCore.Entities;
using ParkingLotWebAPI.Models;
using ParkingLotWebAPI.Services;

namespace ParkingLotWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            CarsService = new CarsService();
            ParkingService = new ParkingService();
            TransactionsService = new TransactionsService();
        }

        public IConfiguration Configuration { get; }

        public CarsService CarsService { get; private set; }
        public ParkingService ParkingService { get; private set; }
        public TransactionsService TransactionsService { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(o =>
                {
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        castedResolver.NamingStrategy = null;
                    }
                });

            services.AddScoped<CarsService>();
            services.AddScoped<ParkingService>();
            services.AddScoped<TransactionsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDto>();
            });

            app.UseMvc();
        }
    }
}
