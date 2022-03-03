using System;

namespace ObservablePipelines
{
    public interface IPipe
    { }

    public interface IPipe<TIn, TOut> : IPipe
    {
        IObservable<TOut> Handle(IObservable<TIn> source);
    }

    public interface IPipelineBuilder
    {
        IPipelineBuilder ConfigurePipeline(Action<IPipelineConfigurationBuilder> configure);

        IPipelineBuilder AddPipe<TPipe>() where TPipe : IPipe;
    }

    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration) where TConfiguration : class;
    }
}