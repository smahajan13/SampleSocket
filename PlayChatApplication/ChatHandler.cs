using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketManager;

namespace PlayChatApplication
{
    public class ChatHandler : WebSocketHandler
    {
        private readonly ChartManager _chartManager;
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager, ChartManager chartManager) : base(webSocketConnectionManager)
        {
            _chartManager = chartManager;
        }
        public async Task SendMessage(string socketId,string message)
        {
           // dynamic dynamicMessage = _chartManager.Messages.Add(new ExpandoObject());
            await InvokeClientMethodToAllAsync("pingMessage",socketId,message);
        }
    }
}
