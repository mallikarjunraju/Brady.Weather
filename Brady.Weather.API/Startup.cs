namespace Brady.Weather.API
{
    using System;
    using System.IO;
    using Brady.Weather.API.Middleware.ErrorHandling;
    using Brady.Weather.API.Services;
    using Brady.Weather.API.Services.Interfaces;
    using Brady.Weather.API.Services.Weather;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>        
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                 .AllowAnyHeader());
            });

            services
                .AddControllers(o =>
                {
                    o.Filters.Add(new ProducesAttribute("application/json"));
                    o.Conventions.Add(new SwaggerApplicationConvention());
                })
                .AddNewtonsoftJson(options => ConfigureJsonSerialization(options.SerializerSettings))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, this.GetType().Assembly.GetName().Name + ".xml"));
                c.ExampleFilters();
                c.EnableAnnotations();
            });

            services.AddHttpClient<IWeatherService, WeatherService>(c => { c.BaseAddress = new Uri(Configuration.GetSection("OpenWeatherMap:Uri").Value); });
            services.AddHttpClient<IForecastService, ForecastService>(c => { c.BaseAddress = new Uri(Configuration.GetSection("OpenWeatherMap:Uri").Value); });
            services.AddHttpClient<IGeoCodingService, GeoCodingService>(c => { c.BaseAddress = new Uri(Configuration.GetSection("OpenWeatherMap:Uri").Value); });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                option =>
                {
                    option.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
                });
        }

        private static void ConfigureJsonSerialization(JsonSerializerSettings serializerSettings)
        {
            serializerSettings.Formatting = Formatting.Indented;
            serializerSettings.FloatParseHandling = FloatParseHandling.Decimal;

            var dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ"
            };
            serializerSettings.Converters.Add(new StringEnumConverter());
            serializerSettings.Converters.Add(dateConverter);
        }

    }
}
