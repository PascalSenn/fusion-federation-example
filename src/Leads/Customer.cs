using System;
using HotChocolate.Types.Relay;

namespace Leads;

public record Customer([property: ID] Guid Id);
