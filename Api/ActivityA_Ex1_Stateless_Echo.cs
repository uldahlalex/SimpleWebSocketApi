using Fleck;

namespace Api;

/// <summary>
/// Totally stateless WebSocket API server which simply "Echos" the message a client sneds
/// </summary>
public class ActivityA_Ex1_Stateless_Echo
{
    public  void Main()
    {
        var server = new WebSocketServer("ws://0.0.0.0:8181");
        server.Start(socket =>
        {
            socket.OnOpen = () => Console.WriteLine("Open!");
            socket.OnClose = () => Console.WriteLine("Close!");
            socket.OnMessage = message => socket.Send("Echo: "+message);
        });
    }
}