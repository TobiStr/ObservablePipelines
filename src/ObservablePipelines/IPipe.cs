using System;

namespace ObservablePipelines
{
    /// <summary>
    /// Represents a pipe that processes an observable input of type <typeparamref name="TIn"/>
    /// and produces an observable output of type <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of the input items.</typeparam>
    /// <typeparam name="TOut">The type of the output items.</typeparam>
    public interface IPipe<TIn, TOut>
    {
        /// <summary>
        /// Handles the processing of the given source observable sequence.
        /// </summary>
        /// <param name="source">The observable sequence of type <typeparamref name="TIn"/> to process.</param>
        /// <returns>An observable sequence of type <typeparamref name="TOut"/> representing the processed output.</returns>
        IObservable<TOut> Handle(IObservable<TIn> source);
    }
}