using Microsoft.Extensions.DependencyInjection;
using ObservablePipelines.Extensions;
using System;

namespace ObservablePipelines.Services
{
    internal class PipelineBuilder : IPipelineBuilder
    {
        private readonly IServiceCollection serviceCollection;

        public PipelineBuilder(IServiceCollection serviceCollection, IServiceProvider serviceProvider) {
            if (serviceCollection is null)
                throw new ArgumentNullException(nameof(serviceCollection));

            this.serviceCollection = serviceCollection.Clone();
            //this.serviceCollection.AddSingleton(serviceProvider);
        }

        private PipelineBuilder(IServiceCollection serviceCollection) {
            if (serviceCollection is null)
                throw new ArgumentNullException(nameof(serviceCollection));

            this.serviceCollection = serviceCollection;
        }

        public IPipelineBuilder ConfigureOptions(
            Action<IPipelineConfigurationBuilder> configure
        ) {
            var configurationBuilder = new PipelineConfigurationBuilder(serviceCollection);

            configure(configurationBuilder);

            return new PipelineBuilder(serviceCollection);
        }

        public IPipelineBuilder<TOut> ConfigurePipeline<TOut>(
            Func<IPipelineSourceBuilder, IPipelineStepBuilder<TOut>> build
        ) {
            var sourceBuilder = new PipelineSourceBuilder(serviceCollection);

            var constructor = (PipelineStepBuilder<TOut>)build(sourceBuilder);

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