using System.ComponentModel;
using System.Reflection;
using ModelContextProtocol.Server;

namespace MattEland.AI.MCPServer.Tools;

[McpServerToolType]
public static class AboutTool
{
    [McpServerTool, Description("Get the name of the person who wrote this tool")]
    public static string GetAuthor() => "Matt Eland";

    [McpServerTool, Description("Get the version number of the MCP Server")]
    public static string GetVersion()
    {
        string? version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        if (version == null)
        {
            throw new InvalidOperationException("Could not get assembly version");
        }

        return version;
    }
    
    [McpServerTool, Description("Get the name of this tool")]
    public static string GetToolName() => "Eland MCPServer Bubba";
}