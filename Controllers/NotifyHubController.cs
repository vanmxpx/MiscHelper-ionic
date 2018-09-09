using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MiscHelper.Hubs;
using MiscHelper.Models;

namespace MiscHelper_ionic.Controllers
{    
    [Route("api/[controller]")]
    public class NotifyHubController: ControllerBase
    {

        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public NotifyHubController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;

            try
            {
                _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            
            return retMessage;
        }
    }
}