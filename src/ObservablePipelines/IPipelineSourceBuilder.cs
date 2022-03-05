using System;

namespace ObservablePipelines
{
    public interface IPipelineSourceBuilder
    {
        IPipelineStepBuilder<TOut> AddSource<TOut>(IObservable<TOut> source);
    }
}