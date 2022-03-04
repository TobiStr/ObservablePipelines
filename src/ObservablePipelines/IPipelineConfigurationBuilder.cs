namespace ObservablePipelines
{
    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration) where TConfiguration : class;
    }
}