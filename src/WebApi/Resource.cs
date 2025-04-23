﻿namespace VictorFrye.Counter.WebApi;

public class Resource
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public string Slug => Name.ToLower().Replace(" ", "-");

    public required string Name { get; set; }

    public int Count { get; set; }
}
