using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StemService.Core.Infrastructure;
using StemService.DependencyResolution;
using StemService.Infrastructure;
using System.Collections.Generic;

namespace StemService
{
    public class Startup
    {
        private ILoggerFactory _loggerFactory = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();

            #region Dependency Resolution ---------------------------------------------------------
            services.RegisterServices(_loggerFactory);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMemoryCache cache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Load & Cache Data from Static File --------------------------------------------
            var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);
            IDataProvider dataProvider = DataProviderFactory.GetDataProvider();
            IList<string> words = dataProvider.GetWordsData();
            cache.Set("WordsDictionary", words, entryOptions);
            #endregion

            app.UseMvc();
        }                  
    }
}
