using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text.Json.Nodes;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DartSocket
{
    public static class WebSocketServerHelper
    {
        static WebSocketServerHelper() // This is called once, right before any of the methods is called and will start the server, so just call `WebSocketServerHelper.SetIpAndPort(ip, port);` and the server will start that address. This way, after you called previous mentioned method you can just call `WebSocketServerHelper.SendMessage(msg);` anyware and it will send the message to all clients
        {
            _ip = "127.0.0.1";
            _port = 5010;
            wssv = InitializeServer();
        }

        public static WebSocketServer wssv { get; set; }

        internal static WebSocketSessionManager SessionManager;
        private static string _ip { get; set; }
        private static ushort _port { get; set; }

        public static void CloseServer()
        {
            wssv.Stop(); // stops the websocket server
        }
        public static void SetIpAndPort(string ip = "127.0.0.1", ushort port = 5010)
        {
            CloseServer();
            _ip = ip;
            _port = port;
            wssv = InitializeServer();

        }
        private static WebSocketServer InitializeServer()
        {
            string addr = string.Format("ws://{0}:{1}", _ip, _port); // formats to the ip and port to the address format
            wssv = new WebSocketServer(addr); // makes a server object on given address.
            wssv.AddWebSocketService<Startup>("/"); // "Startup" is the custom behavior, but that isnt that important, leaving it to the default like below is fine.
            wssv.Start(); // WebSocket server started at \"ip:port\"
            Debug.WriteLine(addr);
            return wssv;
        }

        public static void SendMessage(string msg)
        {

            if (!(wssv is null) && !(SessionManager is null))
            {
                SessionManager.Broadcast(msg);
                // Sending messages to clients
            }
            else
            {
                // WebSocket Server not found.
            }

        }
    }
    public class Startup : WebSocketBehavior
    {
        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }
        protected override void OnOpen()
        {
            // This is ran when a client is connected
            WebSocketServerHelper.SessionManager = Sessions;
            base.OnOpen();
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            // this is ran when a message is recieved from client, where e.data is the string version of the data
            // DataHandler.HandleData(e.data); 
            base.OnMessage(e);
        }
        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }
    }
}