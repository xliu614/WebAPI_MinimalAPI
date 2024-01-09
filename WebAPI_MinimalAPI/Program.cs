using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Inject the services
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

#region minimal api
//var shirts = new[] {
//    new {Id= 1, Color="Red", Size=9 },
//    new {Id= 2, Color="Blue", Size=10}
//};


// Comment out minimal API for now
//app.MapGet("/shirts", () =>
//{
//    return new JsonResult(shirts);
//});

//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"Reading the shirt of ID: {id}";
//});

//app.MapPost("/shirts", () =>
//{
//    return $"A new shirt is saved";
//});


//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updated shirt with ID: {id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleted the shirt with ID: {id}";
//});
#endregion

app.Run();


