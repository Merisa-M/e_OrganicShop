using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eOrganicShop.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eOrganicShop.Service;
using eOrganicShop.Model.Request;
using Microsoft.AspNetCore.Authentication;
using eOrganicShop.Security;
using Microsoft.OpenApi.Models;

namespace eOrganicShop
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
            services.AddAutoMapper(typeof(Startup));
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eOrganicShop API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "basic"
                              }
                          },
                          new string[] {}
                    }
                });
            });


            services.AddDbContext<eOrganicShopContext>(options =>
              options.UseSqlServer(
            Configuration.GetConnectionString("eOrganicShop")));

            services.AddScoped<ICRUDService<Model.VrsteProizvoda, VProizvodaSearchRequest, VProizvodaUpsertRequest, VProizvodaUpsertRequest>, VrsteProizvodaService>();
            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IProizvodiService, ProizvodiService>();
            //services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<IBaseService<Model.Uloge, object>, UlogeService>();
            services.AddScoped<ICRUDService<Model.Transakcije, TransakcijeSearchRequest, TransakcijeUpsertRequest, TransakcijeUpsertRequest>, TransakcijeService>();
            services.AddScoped<ICRUDService<Model.Favoriti, FavoritiSearchRequest, FavoritiUpsertRequest, FavoritiUpsertRequest>, FavoritiService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICRUDService<Model.Kupovine, KupovineSearchRequest, KupovineUpsertRequest, KupovineUpsertRequest>, KupovineService>();
            //services.AddScoped<ICRUDService<Model.Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, NarudzbaService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<ICRUDService<Model.NarudzbaStavke, NarudzbeStavkeSearchRequest, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpsertRequest>, NarudzbaStavkeService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IRecommendationService, RecommendationService>();




            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            //app.UseHttpsRedirection();

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
