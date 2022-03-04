using Microsoft.Extensions.Logging;
using ObservablePipelines.Test.ShowCase.Model;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace ObservablePipelines.Test.ShowCase.Pipes;

internal record MessageFilterPipeOptions(Guid ReceiverId);

internal class MessageFilterPipe : IPipe<ChatMessage, ChatMessage>
{
    private readonly MessageFilterPipeOptions options;

    private readonly ILogger<MessageFilterPipe> logger;

    public MessageFilterPipe(
        MessageFilterPipeOptions options,
        ILogger<MessageFilterPipe> logger
    ) {
        this.options = options
            ?? throw new ArgumentNullException(nameof(options));
        this.logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public IObservable<ChatMessage> Handle(IObservable<ChatMessage> source) {
        return source
            .Where(m => m.ReceiverId == options.ReceiverId)
            .Do(m => logger.LogInformation($"Filter let message: '{m.Message}' pass through."));
    }
}