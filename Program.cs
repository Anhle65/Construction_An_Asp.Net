// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
var greeting = new Greeting().Message("Vanh");

// Creat a host which run on a specific URL before a web application is created
using (
    var host = WebHost.Start("http://localhost:5001",router => router
    .MapGet("hello/{name}", (req, res, data) =>
        res.WriteAsync($"Hello, {data.Values["name"]}!"))
    .MapGet("buenosdias/{name}", (req, res, data) =>
        res.WriteAsync($"Buenos dias, {data.Values["name"]}!"))
    .MapGet("throw/{message?}", (req, res, data) =>
        res.WriteAsync($"{data.Values["message"] ?? "Uh oh!"}"))
    .MapGet("{greeting}/{name}", (req, res, data) =>
        res.WriteAsync($"{data.Values["greeting"]}, {data.Values["name"]}!"))
    .MapGet("", (req, res, data) => res.WriteAsync("Hello, World!"))))
{
    Console.WriteLine("Use Ctrl-C to shut down the host...");
    host.WaitForShutdown();
}
// A web application run on port:5000
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();
app.MapGet("/", () => "It works");
app.MapGet("/Vanh", () => greeting);
app.Run();
