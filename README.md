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

## Pattern Matching
In **Program.cs** you can the method get **/v1/todos**:

```csharp
	app.MapGet("/v1/todos", (AppDbContext context) =>
    {
        var todos = context.Todos;
        return todos is not null ? Results.Ok(todos) : Results.NotFound();
    });
```

In the method return we use a new C# feature called **Pattern Matching**, where I compare `todos is not null` instead of `all != null`.

This comparison allows to return **Results.NotFound() (404)** or **Results.Ok() (200)**.

## Produces

In the Get method **/v1/todos** we can see `Produces<Todo>`. We use **Produces** to define the type returned by the method, so the swagger will support documentation with **Schemas**.

## Dependencies

- SQL Lite:
    `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
- EntityFramework:
    `dotnet add package Microsoft.EntityFrameworkCore.Design`
- FluentValidation
    `dotnet add package FluentValidation`
- Swagger
    `dotnet add package Swashbuckle.AspNetCore`