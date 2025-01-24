using System;

namespace ObservablePipelines
{
    /// <summary>
    /// Provides a builder for configuring pipeline settings and options.
    /// </summary>
    public interface IPipelineConfigurationBuilder
    {
        /// <summary>
        /// Adds a configuration object to the pipeline builder.
        /// </summary>
        /// <typeparam name="TConfiguration">The type of the configuration object.</typeparam>
        /// <param name="configuration">The configuration object to add.</param>
        /// <returns>The current instance of <see cref="IPipelineConfigurationBuilder"/> for method chaining.</returns>
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration) where TConfiguration : class;

        /// <summary>
        /// Adds a configuration object to the pipeline builder using a factory function.
        /// </summary>
        /// <typeparam name="TConfiguration">The type of the configuration object.</typeparam>
        /// <param name="configurationFactory">A factory function to create the configuration object using an <see cref="IServiceProvider"/>.</param>
        /// <returns>The current instance of <see cref="IPipelineConfigurationBuilder"/> for method chaining.</returns>
        IPipelineConfigurationBuilder Add<TConfiguration>(
            Func<IServiceProvider, TConfiguration> configurationFactory
        ) where TConfiguration : class;
    }

}