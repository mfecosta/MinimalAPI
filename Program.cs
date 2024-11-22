using MinimalApi.Data;
using MinimalApi.Models;
using MinimalApi.Models.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();//AddDbContext gerencia toda a conex�o de banco de dados funciona em muitos DB's, garante que teremos a
// apenas uma conex�o por requisi��o
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

SQLitePCL.Batteries.Init();


app.MapGet("V1/todos", (ApplicationDbContext context) => {
    var todos = context.Todos.ToList();
    return Results.Ok(todos);

});


app.MapPost("V1/todos",(  
    ApplicationDbContext context,
    CreateTodo model) => {

    var todo = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);
        context.Todos.Add(todo);   
        context.SaveChanges(); 

        return Results.Created($"V1/todos/{todo.id}", todo);

    });



app.Run();
