using Microsoft.Extensions.Logging;
using ObservablePipelines.Test.ShowCase.Model;
using System;
using System.Reactive.Linq;

namespace ObservablePipelines.Test.ShowCase.Pipes;

internal class LoggerPipe : IPipe<ChatMessage, ChatMessage>
{
    private readonly ILogger<LoggerPipe> logger;

    public LoggerPipe(ILogger<LoggerPipe> logger) {
        this.logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public IObservable<ChatMessage> Handle(IObservable<ChatMessage> source) {
        return source.Do(m => logger.LogInformation($"Pipeline triggered for message: '{m.Message}'."));
    }
}