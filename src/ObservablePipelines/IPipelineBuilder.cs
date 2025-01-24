using System;

namespace ObservablePipelines
{
    /// <summary>
    /// Provides a builder for configuring and creating a pipeline.
    /// </summary>
    public interface IPipelineBuilder
    {
        /// <summary>
        /// Configures the pipeline options using the specified configuration builder action.
        /// </summary>
        /// <param name="build">An action that configures the pipeline using the provided <see cref="IPipelineConfigurationBuilder"/>.</param>
        /// <returns>The current instance of <see cref="IPipelineBuilder"/> for method chaining.</returns>
        IPipelineBuilder ConfigureOptions(
            Action<IPipelineConfigurationBuilder> build
        );

        /// <summary>
        /// Configures the pipeline and specifies the output type.
        /// </summary>
        /// <typeparam name="TOut">The type of the output produced by the pipeline.</typeparam>
        /// <param name="build">A function that builds the pipeline using the provided <see cref="IPipelineSourceBuilder"/> and <see cref="IPipelineStepBuilder{TOut}"/>.</param>
        /// <returns>An <see cref="IPipelineBuilder{TOut}"/> instance for building the pipeline.</returns>
        IPipelineBuilder<TOut> ConfigurePipeline<TOut>(
            Func<IPipelineSourceBuilder,
            IPipelineStepBuilder<TOut>> build
        );
    }

    /// <summary>
    /// Represents a builder for creating a pipeline with a specified output type.
    /// </summary>
    /// <typeparam name="TOut">The type of the output produced by the pipeline.</typeparam>
    public interface IPipelineBuilder<out TOut>
    {
        /// <summary>
        /// Builds the pipeline and returns the resulting observable sequence.
        /// </summary>
        /// <returns>An <see cref="IObservable{TOut}"/> representing the pipeline output.</returns>
        IObservable<TOut> Build();
    }

}