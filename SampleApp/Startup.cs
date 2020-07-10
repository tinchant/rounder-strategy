using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleDomain;

namespace SampleApp
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
            services.AddControllers();
            services.AddTransient<IEnumerable<IRoundStrategy>>(RoundStrategyFactory);
            services.AddTransient<RounderService>();
        }

        private IEnumerable<IRoundStrategy> RoundStrategyFactory(IServiceProvider arg)
        {
            var rounderOptionRepository = new RounderOptionRepository(); //repositorio que diz como vamos arredondar
            var options = rounderOptionRepository.Get();
            foreach (var option in options)
            {
                switch (option)
                {
                    case RounderOption.A:
                        yield return new ARounder();
                        break;
                    case RounderOption.B:
                        yield return new BRounder();
                        break;
                    case RounderOption.C:
                        yield return new CRounder();
                        break;
                    default:
                        break;
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
