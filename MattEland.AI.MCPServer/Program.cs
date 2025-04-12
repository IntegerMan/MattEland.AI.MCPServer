using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(options =>
{
   options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Add in our Model Context Protocol server setup
builder.Services.AddMcpServer()
   .WithStdioServerTransport()
   .WithToolsFromAssembly(); // TODO: Should take this from a tools assembly likely
   
IHost host = builder.Build();
host.Run();