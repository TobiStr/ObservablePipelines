using Microsoft.Extensions.DependencyInjection;
using ObservablePipelines.Extensions;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineConstructor<TIn> : IPipelineConstructor<TIn>
    {
        private readonly IServiceCollection serviceCollection;

        public IObservable<TIn> Source { get; }

        public PipelineConstructor(
            IObservable<TIn> source,
            IServiceCollection serviceCollection
        ) {
            this.Source = source
                ?? throw new ArgumentNullException(nameof(source));
            this.serviceCollection = serviceCollection
                ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public IPipelineConstructor<TOut> Pipe<TOut>(IPipe<TIn, TOut> pipe) {
            return new PipelineConstructor<TOut>(Source.Pipe(pipe), serviceCollection);
        }

        public IPipelineConstructor<TOut> Pipe<TPipe, TOut>() where TPipe : class, IPipe<TIn, TOut> {
            var serviceProvider = serviceCollection
                .AddTransient<TPipe>()
                .BuildServiceProvider();
            var pipe = serviceProvider.GetRequiredService<TPipe>();

            return new PipelineConstructor<TOut>(Source.Pipe(pipe), serviceCollection);
        }
    }
}