using Microsoft.Extensions.Logging;
using ObservablePipelines.Test.ShowCase.Abstractions;
using ObservablePipelines.Test.ShowCase.Model;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace ObservablePipelines.Test.ShowCase.Pipes;

internal class MessageTransformPipe : IPipe<ChatMessage, IdentifiedChatMessage>
{
    private readonly IUserRepository userRepository;

    private readonly ILogger<MessageTransformPipe> logger;

    public MessageTransformPipe(
        IUserRepository userRepository,
        ILogger<MessageTransformPipe> logger
    ) {
        this.userRepository = userRepository
            ?? throw new ArgumentNullException(nameof(userRepository));
        this.logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public IObservable<IdentifiedChatMessage> Handle(IObservable<ChatMessage> source) {
        return source
            .Select(IdentifyMessage)
            .Do(m => logger.LogInformation($"Identified sender: '{m.SenderName}'."));
    }

    private IdentifiedChatMessage IdentifyMessage(ChatMessage m) {
        return new(
            Message: m.Message,
            SenderName: userRepository.GetUserName(m.SenderId),
            SendDate: m.SendDate
        );
    }
}