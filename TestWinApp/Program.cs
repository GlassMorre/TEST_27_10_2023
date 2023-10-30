using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Headers;
using System.Collections.Generic;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5055",
                                              "http://localhost:5056");
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders();

app.MapGet("/add/{a}/{b}", (int a, int b) =>
{
    return a + b;
})
.WithName("GetAddResult")
.WithOpenApi();

app.Run();
