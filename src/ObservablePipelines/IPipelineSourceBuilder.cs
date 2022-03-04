using System;

namespace ObservablePipelines
{
    public interface IPipelineSourceBuilder
    {
        IPipelineConstructor<TOut> AddSource<TOut>(IObservable<TOut> source);
    }
}