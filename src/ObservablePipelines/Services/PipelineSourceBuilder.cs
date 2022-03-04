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

        public IPipelineConstructor<TOut> AddSource<TOut>(IObservable<TOut> source) {
            return new PipelineConstructor<TOut>(source, serviceCollection);
        }
    }
}