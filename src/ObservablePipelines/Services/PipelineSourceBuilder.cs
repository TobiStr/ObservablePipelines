using Microsoft.Extensions.DependencyInjection;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineSourceBuilder : IPipelineSourceBuilder
    {
        private readonly IServiceCollection serviceCollection;

        public PipelineSourceBuilder(IServiceCollection serviceCollection) {
            this.serviceCollection = serviceCollection
                ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public IPipelineStepBuilder<TOut> AddSource<TOut>(IObservable<TOut> source)
            => new PipelineStepBuilder<TOut>(source, serviceCollection);
    }
}