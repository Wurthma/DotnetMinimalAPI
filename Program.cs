using MiniTodo.Data;
using MiniTodo.ViewModels;
using FluentValidation;
using MiniTodo.ViewModels.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health-check", () => Results.Ok("Minimal API works!"));

app.MapGet("/v1/todos", (AppDbContext context) =>
{
    var todos = context.Todos;
    return todos is not null ? Results.Ok(todos) : Results.NotFound();
}).Produces<Todo>();

app.MapPost("/v1/todos", (AppDbContext context, CreateTodoViewModel model) =>
{
    var todo = model.MapTo();

    var validator = new CreateTodoViewModelValidator();
    var result = validator.Validate(model);

    if (!result.IsValid)
        return Results.BadRequest(result.Errors);

    context.Todos.Add(todo);
    context.SaveChanges();

    return Results.Created($"/v1/todos/{todo.Id}", todo);
});

app.Run();
