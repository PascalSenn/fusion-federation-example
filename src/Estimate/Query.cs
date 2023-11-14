using System;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Estimates;

public class Query
{
    public Estimate GetEstimate([ID<Estimate>] Guid id) => new Estimate($"Estimate {id}");
}

public sealed class Estimate
{
    public Estimate(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public Guid ClientId { get; } = Guid.NewGuid();
}

[ExtendObjectType<Estimate>]
public class EstimateExtensions
{
    [BindMember(nameof(Estimate.ClientId))]
    public Customer GetCustomer([Parent] Estimate parent) => new(parent.ClientId);
}

public record Customer([property: ID] Guid Id);
