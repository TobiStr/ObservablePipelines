using Microsoft.Extensions.DependencyInjection;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineConfigurationBuilder : IPipelineConfigurationBuilder
    {
        private readonly IServiceCollection services;

        public PipelineConfigurationBuilder(IServiceCollection services) {
            this.services = services
                ?? throw new ArgumentNullException(nameof(services));
        }

        public IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration)
            where TConfiguration : class {
            services.AddSingleton(configuration);
            return this;
        }

        public IPipelineConfigurationBuilder Add<TConfiguration>(
            Func<IServiceCollection, TConfiguration> configurationFactory
        ) where TConfiguration : class {
            services.AddSingleton(configurationFactory);
            return this;
        }
    }
}