using System;

namespace ObservablePipelines
{
    /// <summary>
    /// Provides a builder for adding sources to a pipeline.
    /// </summary>
    public interface IPipelineSourceBuilder
    {
        /// <summary>
        /// Adds a source observable to the pipeline.
        /// </summary>
        /// <typeparam name="TOut">The type of the items produced by the source observable.</typeparam>
        /// <param name="source">The source observable to add to the pipeline.</param>
        /// <returns>An <see cref="IPipelineStepBuilder{TOut}"/> for further pipeline configuration.</returns>
        IPipelineStepBuilder<TOut> AddSource<TOut>(IObservable<TOut> source);
    }

}