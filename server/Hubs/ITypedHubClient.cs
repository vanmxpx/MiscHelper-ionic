using System.Threading.Tasks;

namespace MiscHelper.Hubs
{
  public interface ITypedHubClient 
  {
    Task BroadcastMessage(string type, string payload);
  }
}