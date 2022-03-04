using System;

namespace ObservablePipelines
{
    public interface IPipe<TIn, TOut>
    {
        IObservable<TOut> Handle(IObservable<TIn> source);
    }
}