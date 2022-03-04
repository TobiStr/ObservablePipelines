using System;

namespace ObservablePipelines
{
    public interface IPipelineBuilder
    {
        IPipelineBuilder Configure(Action<IPipelineConfigurationBuilder> configure);

        IPipelineBuilder<TOut> Construct<TOut>(Func<IPipelineSourceBuilder, IPipelineConstructor<TOut>> build);
    }

    public interface IPipelineBuilder<out TOut>
    {
        IObservable<TOut> Build();
    }
}