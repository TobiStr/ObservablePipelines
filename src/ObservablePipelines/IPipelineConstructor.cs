namespace ObservablePipelines
{
    public interface IPipelineConstructor<TIn>
    {
        IPipelineConstructor<TOut> Pipe<TOut>(IPipe<TIn, TOut> pipe);

        IPipelineConstructor<TOut> Pipe<TPipe, TOut>()
            where TPipe : class, IPipe<TIn, TOut>;
    }
}