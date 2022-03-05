using ObservablePipelines.Test.ShowCase.Model;
using System;
using System.Reactive.Linq;

namespace ObservablePipelines.Test.ShowCase.Pipes;

internal class ConsoleLoggerPipe : IPipe<IdentifiedChatMessage, IdentifiedChatMessage>
{
    public IObservable<IdentifiedChatMessage> Handle(IObservable<IdentifiedChatMessage> source) {
        return source
            .Do(m =>
                Console.WriteLine($"Pipeline finished with message: '{m.Message}'.")
            );
    }
}