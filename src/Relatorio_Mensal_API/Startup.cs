using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Relatorio_Mensal_API.Application.Mapper;
using Relatorio_Mensal_API.Repositories;
using Relatorio_Mensal_API.Repositories.Contrants;
using Relatorio_Mensal_API.Repositories.HoursWorked.CreateRepository;
using Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser;

namespace Relatorio_Mensal_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mapperConfig.CreateMapper();
            services.AddControllers();
            services.AddTransient<IHoursWorkedRepository, HoursWorkedRepository>();
            services.AddTransient<IGetByUserRepository, GetByUserRepository>();
            services.AddTransient<ICreateRepository, CreateRepository>();
            services.AddMediatR(typeof(Startup));
            services.AddSingleton(mapper);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Relatorio_Mensal_API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Relatorio_Mensal_API v1"));
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
