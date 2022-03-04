using System;

namespace ObservablePipelines.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<TOut> Pipe<TIn, TOut>(
            this IObservable<TIn> source,
            IPipe<TIn, TOut> pipe
        ) => pipe.Handle(source);
    }
}