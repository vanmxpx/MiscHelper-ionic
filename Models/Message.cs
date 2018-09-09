using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MiscHelper.Models
{
    public class Message 
    {
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}