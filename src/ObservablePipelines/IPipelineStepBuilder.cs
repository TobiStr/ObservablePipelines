using System;

namespace ObservablePipelines
{
    /// <summary>
    /// Provides a builder for adding processing steps to a pipeline.
    /// </summary>
    /// <typeparam name="TIn">The type of the input items for the pipeline step.</typeparam>
    public interface IPipelineStepBuilder<TIn>
    {
        /// <summary>
        /// Adds a processing step to the pipeline using the specified pipe.
        /// </summary>
        /// <typeparam name="TOut">The type of the output items produced by the pipe.</typeparam>
        /// <param name="pipe">The pipe that defines the processing step.</param>
        /// <returns>An <see cref="IPipelineStepBuilder{TOut}"/> for further pipeline configuration.</returns>
        IPipelineStepBuilder<TOut> AddStep<TOut>(IPipe<TIn, TOut> pipe);

        /// <summary>
        /// Adds a processing step to the pipeline using a pipe of the specified type.
        /// </summary>
        /// <typeparam name="TPipe">The type of the pipe that defines the processing step.</typeparam>
        /// <typeparam name="TOut">The type of the output items produced by the pipe.</typeparam>
        /// <returns>An <see cref="IPipelineStepBuilder{TOut}"/> for further pipeline configuration.</returns>
        IPipelineStepBuilder<TOut> AddStep<TPipe, TOut>()
            where TPipe : class, IPipe<TIn, TOut>;

        /// <summary>
        /// Adds a processing step to the pipeline using a factory function.
        /// </summary>
        /// <typeparam name="TOut">The type of the output items produced by the processing step.</typeparam>
        /// <param name="resultFactory">A factory function that processes the input observable sequence and produces an output observable sequence.</param>
        /// <returns>An <see cref="IPipelineStepBuilder{TOut}"/> for further pipeline configuration.</returns>
        IPipelineStepBuilder<TOut> AddStep<TOut>(Func<IObservable<TIn>, IObservable<TOut>> resultFactory);
    }

}