using AutoMapper;
using GentilCareBack.Models.Entity;
using GentilCareBack.Models.Persistencia;
using GentilCareBack.Services.AutoMapper;
using GentilCareBack.Services.Implements;
using GentilCareBack.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GentilCareBack
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
            services.AddControllers();

            services.AddDbContext<dbContextDataBase>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            /*
            services.AddDbContext<dbContextDataBase>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ConexionDb"), b=> b.MigrationsAssembly("GentilCareBack.Models"));
            });
            */
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles))); //If you have other mapping profiles defined, that profiles will be loaded too.
            //services.AddAutoMapper(Assembly.Load("GentilCareBack.Services"));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            /*
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            */
            services.AddSingleton<IAddressesService, AddressesService>();
            services.AddSingleton<IAparatoRespiratorioService, AparatoRespiratorioService>();
            services.AddSingleton<IAuthsService, AuthsService>();
            services.AddSingleton<ICardioVascularService, CardioVascularService>();
            services.AddSingleton<IColaboradorsService, ColaboradorsService>();
            services.AddSingleton<IEsfera_PsiquicaService, Esfera_PsiquicaService>();

            services.AddSingleton<IEspecialidadsService, EspecialidadsService>();
            services.AddSingleton<IEstudiosService, EstudiosService>();
            services.AddSingleton<IFarmacosService, FarmacosService>();
            services.AddSingleton<IInterrogatoriosService, InterrogatoriosService>();
            services.AddSingleton<IMotivosService, MotivosService>();
            services.AddSingleton<IPielTegumentosService, PielTegumentosService>();

            services.AddSingleton<IPreguntasService, PreguntasService>();
            services.AddSingleton<IRecetasService, RecetasService>();
            services.AddSingleton<IRolesService, RolesService>();
            services.AddSingleton<ISentidosService, SentidosService>();
            services.AddSingleton<IServiciosService, ServiciosService>();
            services.AddSingleton<ISignosvitalesService, SignosvitalesService>();

            services.AddSingleton<ISintomasGeneralesService, SintomasGeneralesService>();
            services.AddSingleton<ISistemaDigestivoService, SistemaDigestivoService>();
            services.AddSingleton<ISistemaEmatopoyeticoService, SistemaEmatopoyeticoService>();
            services.AddSingleton<ISistemaEndocrinoService, SistemaEndocrinoService>();
            services.AddSingleton<ISistemaMusculoEsqueleticoService, SistemaMusculoEsqueleticoService>();
            services.AddSingleton<ISistemaNerviosoService, SistemaNerviosoService>();

            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IPlanesService, PlanesService>();
            services.AddSingleton<IMedicamentoService, MedicamentoService>();
            services.AddSingleton<IProveedorService, ProveedorService>();
            services.AddSingleton<ISemanaService, SemanaService>();
            services.AddSingleton<IHoraService, HoraService>();
            //            services.AddTransient<Addresses>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
