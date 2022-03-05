using System;

namespace ObservablePipelines
{
    public interface IPipelineBuilder
    {
        IPipelineBuilder ConfigureOptions(
            Action<IPipelineConfigurationBuilder> build
        );

        IPipelineBuilder<TOut> ConfigurePipeline<TOut>(
            Func<IPipelineSourceBuilder,
            IPipelineStepBuilder<TOut>> build
        );
    }

    public interface IPipelineBuilder<out TOut>
    {
        IObservable<TOut> Build();
    }
}