using System;

namespace ObservablePipelines.Extensions
{
    /// <summary>
    /// Provides extension methods for working with observables and pipes.
    /// </summary>
    public static class ObservableExtensions
    {
        /// <summary>
        /// Pipes the source observable through the specified pipe.
        /// </summary>
        /// <typeparam name="TIn">The type of the input items.</typeparam>
        /// <typeparam name="TOut">The type of the output items.</typeparam>
        /// <param name="source">The source observable to process.</param>
        /// <param name="pipe">The pipe that processes the source observable.</param>
        /// <returns>An <see cref="IObservable{TOut}"/> representing the processed output.</returns>
        public static IObservable<TOut> Pipe<TIn, TOut>(
            this IObservable<TIn> source,
            IPipe<TIn, TOut> pipe
        ) => pipe.Handle(source);

        /// <summary>
        /// Pipes the source observable through the specified factory function.
        /// </summary>
        /// <typeparam name="TIn">The type of the input items.</typeparam>
        /// <typeparam name="TOut">The type of the output items.</typeparam>
        /// <param name="source">The source observable to process.</param>
        /// <param name="pipe">A factory function that processes the source observable.</param>
        /// <returns>An <see cref="IObservable{TOut}"/> representing the processed output.</returns>
        public static IObservable<TOut> Pipe<TIn, TOut>(
            this IObservable<TIn> source,
            Func<IObservable<TIn>, IObservable<TOut>> pipe
        ) => pipe(source);
    }

}