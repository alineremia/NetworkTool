using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public interface INetworkToolManager
{
    bool IsNetworkAvailable();
    string GetNetworkConfiguration(string adapterName);
    NetworkInterface[] GetAllNetworkAdapters();
}
