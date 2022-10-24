using System;

namespace ObservablePipelines
{
    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration) where TConfiguration : class;

        IPipelineConfigurationBuilder Add<TConfiguration>(
            Func<IServiceProvider, TConfiguration> configurationFactory
        ) where TConfiguration : class;
    }
}