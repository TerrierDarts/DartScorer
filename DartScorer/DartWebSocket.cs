using System;
using WebSocketSharp;

public class WebSocketClient
{
    private WebSocket _webSocket;

    public WebSocketClient(string url)
    {
        _webSocket = new WebSocket(url);
        _webSocket.OnOpen += (sender, e) =>
        {
            Console.WriteLine("WebSocket connection opened");
        };
        _webSocket.OnMessage += (sender, e) =>
        {
            Console.WriteLine("Received: " + e.Data);
        };
        _webSocket.OnError += (sender, e) =>
        {
            Console.WriteLine("Error: " + e.Message);
        };
        _webSocket.OnClose += (sender, e) =>
        {
            Console.WriteLine("WebSocket connection closed");
        };
    }

    public void Connect()
    {
        _webSocket.Connect();
    }

    public void SendText(string text)
    {
        _webSocket.Send(text);
    }
}