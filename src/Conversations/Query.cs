using System;
using System.Collections.Generic;

namespace Conversations;

public class Query
{
    public IEnumerable<ConversationModel> GetConversations() => new[]
    {
        new ConversationModel()
        {
            Conversation = "Hello, how are you?",
        },
        new ConversationModel()
        {
            Conversation = "I'm fine, thank you.",
        }
    };
}

public class ConversationModel
{
    public Guid LeadId { get; set; }

    public string? Conversation { get; set; }
}
