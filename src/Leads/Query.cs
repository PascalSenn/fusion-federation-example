using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Leads;

public class Query
{
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

    public LeadModel GetLeadModelById([ID] Guid id) => new LeadModel()
    {
        Id = id,
        Name = "John Doe",
    };

    public IEnumerable<LeadModel> GetLeadModelsById([ID] IEnumerable<Guid> ids) => ids.Select(id
        => new LeadModel()
        {
            Id = id,
            Name = "John Doe",
        });
}

public class LeadModel
{
    [ID]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [ID<Customer>]
    public Guid CustomerId { get; set; }
}

[ExtendObjectType<LeadModel>]
public class LeadModelExtensions
{
    public Customer GetClient([Parent] LeadModel parent) => new Customer(parent.CustomerId);
}
