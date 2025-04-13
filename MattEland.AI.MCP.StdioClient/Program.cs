using System.Reflection;
using MattEland.AI.MCP.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol.Types;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Add in our Model Context Protocol server setup
builder.Services.AddMcpServer(options =>
    {
        options.ServerInfo = new Implementation
        {
            Name = "Eland MCPServer",
            Version = Assembly.GetExecutingAssembly().GetName().Version!.ToString()!
        };
    })
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(AboutTool).Assembly);

IHost host = builder.Build();
host.Run();