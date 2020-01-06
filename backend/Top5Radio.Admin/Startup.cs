using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Top5Radio.Admin.Domain;
using Top5Radio.Admin.Persistance.Repository;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin
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
            services.AddTransient<IMusicRepository, MusicRepository>();

            services.AddTransient<IMusicDomainService, MusicDomainService>();

            services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Domain.Models.Music, Persistance.Data.MusicData>().ReverseMap();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors((options) =>
            {
                options.AddDefaultPolicy((builder) =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
