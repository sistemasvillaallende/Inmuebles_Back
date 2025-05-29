using Web_Api_Auto.Services;
using Web_Api_Inm.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Web_Api_Inm.Services.LOGIN;
using System.Text;

namespace Web_Api_Inm
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "TuIssuer", // debe coincidir con el que usás en el micro de auth
                            ValidAudience = "TuAudience", // debe coincidir también
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-long-secret-key-that-is-at-least-32-characters"))
                        };
                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("❌ Error de autenticación: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("✅ Token validado correctamente para: " + context.Principal.Identity.Name);
                                return Task.CompletedTask;
                            }
                        };
                    });
            services.AddControllers();
            services.AddSwaggerGen();
            // configure DI for application services
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<ICtasctes_inmueblesServices, Ctasctes_inmueblesServices>();
            services.AddScoped<ICedulonesServices, CedulonesServices>();
            services.AddScoped<IConceptos_inmuebleService, Conceptos_inmuebleService>();
            services.AddScoped<ITarjetasServices, TarjetasServices>();
            services.AddScoped<IDescadic_x_inmuebleService, Descadic_x_inmuebleService>();
            services.AddScoped<IInmueblesService, InmueblesServices>();
            services.AddScoped<ITarjetasDebitoService, TarjetasDebitoService>();
            services.AddScoped<IDebitosInmuebleService, DebitosInmuebleService>();
            //
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
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
