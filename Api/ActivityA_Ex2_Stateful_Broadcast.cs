using Fleck;

namespace Api;

/// <summary>
/// Stateful WebSocket API server which has a very simple list of client connections to broadcast to
/// </summary>
public class ActivityA_Ex2_Stateful_Broadcast
{
    public List<IWebSocketConnection> Connections { get; set; } = new List<IWebSocketConnection>();
    
    public  void Main()
    {
        var server = new WebSocketServer("ws://0.0.0.0:8181");
        server.Start(socket =>
        {
            socket.OnOpen = () => Connections.Add(socket);
            socket.OnClose = () => Connections.Remove(socket);
            socket.OnMessage = message => Connections.ForEach(c 
                => c.Send("Client with ID "+c.ConnectionInfo.Id+" broadcasts: '"+message+"' to everyone"));
        });
    }
}