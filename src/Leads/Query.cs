using System;
using System.Collections.Generic;

namespace Leads;

public class Query
{
    public ConversationModel GetConversationByLeadId(Guid leadId) => new ConversationModel()
    {
        Lead = new LeadModel()
        {
            Id = leadId,
            Name = "John Doe",
        }
    };

    public IEnumerable<LeadModel> Leads() => new[]
    {
        new LeadModel()
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
        },
        new LeadModel()
        {
            Id = Guid.NewGuid(),
            Name = "Jane Doe",
        }
    };
}

public class ConversationModel
{
    public Guid LeadId { get; set; }

    public LeadModel? Lead { get; set; }
}

public class LeadModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
}
