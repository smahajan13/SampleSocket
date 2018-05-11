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
            dynamic dynamicMessage = new ExpandoObject();
            dynamicMessage.UserId = socketId;
            dynamicMessage.Message = message;
           _chartManager.Messages.Add(dynamicMessage);
            await InvokeClientMethodToAllAsync("pingMessage",dynamicMessage.UserId,dynamicMessage.Message);
        }
    }
}
