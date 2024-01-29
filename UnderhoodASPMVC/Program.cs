// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Builder;

var greeting = new Greeting().Message("Vanh");
Console.WriteLine($"Hello, World!");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "It works");
app.MapGet("/Vanh", () => greeting);
app.Run();