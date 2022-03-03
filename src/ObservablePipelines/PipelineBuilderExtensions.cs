using System;

namespace ObservablePipelines
{
    public static class PipelineBuilderExtensions
    {
        public static IPipelineBuilder ConfigurePipeline(
            this IPipelineBuilder pipelineBuilder,
            Action<IPipelineConfigurationBuilder> configure
        ) {
            throw new NotImplementedException();
        }
    }
}