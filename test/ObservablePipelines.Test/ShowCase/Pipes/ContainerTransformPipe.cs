using ObservablePipelines.Test.ShowCase.Model;
using System;
using System.Reactive.Linq;

namespace ObservablePipelines.Test.ShowCase.Pipes;

internal class ContainerTransformPipe : IPipe<ChatMessage, ChatMessage>
{
    private readonly TestContainer testContainer;

    public ContainerTransformPipe(TestContainer testContainer) {
        this.testContainer = testContainer ?? throw new ArgumentNullException(nameof(testContainer));
    }

    public IObservable<ChatMessage> Handle(IObservable<ChatMessage> source) {
        return source
            .Do(m =>
                testContainer.Number = 2
            );
    }
}