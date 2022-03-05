using Microsoft.Extensions.DependencyInjection;
using ObservablePipelines.Extensions;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineStepBuilder<TIn> : IPipelineStepBuilder<TIn>
    {
        private readonly IServiceCollection serviceCollection;

        public IObservable<TIn> Source { get; }

        public PipelineStepBuilder(
            IObservable<TIn> source,
            IServiceCollection serviceCollection
        ) {
            this.Source = source
                ?? throw new ArgumentNullException(nameof(source));
            this.serviceCollection = serviceCollection
                ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public IPipelineStepBuilder<TOut> AddStep<TOut>(IPipe<TIn, TOut> pipe)
            => new PipelineStepBuilder<TOut>(Source.Pipe(pipe), serviceCollection);

        public IPipelineStepBuilder<TOut> AddStep<TPipe, TOut>() where TPipe : class, IPipe<TIn, TOut> {
            var serviceProvider = serviceCollection
                .AddTransient<TPipe>()
                .BuildServiceProvider();

            var pipe = serviceProvider.GetRequiredService<TPipe>();

            return new PipelineStepBuilder<TOut>(Source.Pipe(pipe), serviceCollection);
        }
    }
}