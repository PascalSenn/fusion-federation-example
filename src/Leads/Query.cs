using System;
using System.Collections.Generic;

namespace Leads;

public class Query
{
    /// <summary>
    /// If the Get{NameOfType}By{FieldId} does not match, you have to specify it in the
    /// schema.extension.graphql file
    /// </summary>
    /// <param name="leadId"></param>
    /// <returns></returns>
    public ConversationModel GetConversationByLeadId(Guid leadId) => new ConversationModel()
    {
        Lead = new LeadModel()
        {
            Id = leadId,
            Name = "John Doe",
        }
    };

    /// <summary>
    /// If Get{NameOfType}By{FieldId} matches the Type and the Field it will be used as the
    /// resolver.
    /// </summary>
    /// <param name="leadId"></param>
    /// <returns></returns>
    public ConversationModel GetConversationModelByLeadId(Guid leadId) => new ConversationModel()
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
