# Description

Minimal API with dotnet 6.

## Instructions

- To create a minimal API use below command:
    `dotnet new web -o DotnetMinimalAPI`

You can use `dotnet new mvc | razorpages` to create templates more robust.

## Creating records

C# 9 introduced a new type for data structures, called **Record**, which allows you to feature objects in simpler structures.

This type is the perfect case for our scenario, as we won't have any behavior here, just data.

In `Models/Todo.cs` we can see an example of **Record**.

`public record Todo(Guid Id, string Title, bool Done);`

## Dependencies

- SQL Lite:
    `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
- EntityFramework:
    `dotnet add package Microsoft.EntityFrameworkCore.Design`