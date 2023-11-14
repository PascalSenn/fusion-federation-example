using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using HotChocolate.Types.Relay;

namespace Customers;

public class Query
{
    private readonly Faker _faker = new();

    public Customer GetCustomerById([ID<Customer>] Guid id)
        => new(id, _faker.Person.FullName, _faker.Person.Email);

    public IReadOnlyList<Customer> GetCustomerByIds([ID<Customer>] IReadOnlyList<Guid> ids)
        => ids.Select(x => new Customer(x, _faker.Person.FullName, _faker.Person.Email)).ToList();
}

public record Customer([property: ID] Guid Id, string Name, string Email);
