using System;

namespace ObservablePipelines.Test.ShowCase.Model;

internal record ChatMessage(
    string Message,
    Guid SenderId,
    Guid ReceiverId,
    DateTime SendDate
);

internal record IdentifiedChatMessage(
    string Message,
    string SenderName,
    DateTime SendDate
);

internal class TestContainer
{
    public int Number { get; set; }

    public TestContainer(int number) {
        Number = number;
    }
}