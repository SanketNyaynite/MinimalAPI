var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();              //is an extension method that adds services required for using controllers in an ASP.NET Core application. It sets up the necessary infrastructure for handling HTTP requests and routing them to the appropriate controller actions.


var app = builder.Build();

// Enable Swagger and Swagger UI
if (app.Environment.IsDevelopment()) // Optional: restrict to development
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();


//BELOW IS EXAMPLE CODE FOR ROUTING SHIRTS USING MINIMAL API - COMMENTED OUT FOR NOW
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

////Routing Shirts
//app.MapGet("/shirts", () =>
//{
//    return "Reading all the shirts";
//});

//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"Reading shirt with ID: {id}";
//});

//app.MapPost("/shirts", () =>
//{
//    return "Creating a new shirt";
//});

//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updating shirt with ID: {id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleting shirt with ID: {id}";
//});

app.Run();

