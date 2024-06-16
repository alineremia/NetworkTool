using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public interface INetworkInterfaceService
{
    bool IsNetworkAvailable();
    NetworkInterface[] GetAllNetworkAdapters();
    NetworkInterface? GetAdapterByName(string adapterName);
}
