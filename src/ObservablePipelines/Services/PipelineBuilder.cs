using Microsoft.Extensions.DependencyInjection;
using ObservablePipelines.Extensions;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineBuilder : IPipelineBuilder
    {
        private readonly IServiceCollection serviceCollection;

        public PipelineBuilder(IServiceCollection serviceCollection) {
            this.serviceCollection = serviceCollection?.Clone()
                ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public IPipelineBuilder Configure(
            Action<IPipelineConfigurationBuilder> configure
        ) {
            var configurationBuilder = new PipelineConfigurationBuilder(serviceCollection);

            configure(configurationBuilder);

            return new PipelineBuilder(serviceCollection);
        }

        public IPipelineBuilder<TOut> Construct<TOut>(
            Func<IPipelineSourceBuilder, IPipelineConstructor<TOut>> build
        ) {
            var sourceBuilder = new PipelineSourceBuilder(serviceCollection);

            var constructor = (PipelineConstructor<TOut>)build(sourceBuilder);

            return new PipelineBuilder<TOut>(constructor.Source);
        }
    }

    internal class PipelineBuilder<TOut> : IPipelineBuilder<TOut>
    {
        private readonly IObservable<TOut> source;

        public PipelineBuilder(IObservable<TOut> source) {
            this.source = source
                ?? throw new ArgumentNullException(nameof(source));
        }

        public IObservable<TOut> Build() {
            return source;
        }
    }
}