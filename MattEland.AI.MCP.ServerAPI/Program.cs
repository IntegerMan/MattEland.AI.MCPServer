using System.Reflection;
using MattEland.AI.MCP.Tools;
using ModelContextProtocol.Protocol.Types;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

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

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapMcp();

app.Run();
