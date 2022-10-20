using System;

namespace ObservablePipelines
{
    public interface IPipelineStepBuilder<TIn>
    {
        IPipelineStepBuilder<TOut> AddStep<TOut>(IPipe<TIn, TOut> pipe);

        IPipelineStepBuilder<TOut> AddStep<TPipe, TOut>()
            where TPipe : class, IPipe<TIn, TOut>;

        IPipelineStepBuilder<TOut> AddStep<TOut>(Func<IObservable<TIn>, IObservable<TOut>> resultFactory);
    }
}