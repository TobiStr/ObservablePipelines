using System;

namespace ObservablePipelines
{
    public interface IPipe<TIn, TOut>
    {
        IObservable<TOut> Handle(IObservable<TIn> source);
    }

    public interface IPipelineBuilder
    {
        IPipe<TIn, TOut> Build<TIn, TOut>();
    }

    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration);
    }
}