using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public class NetworkInterfaceService : INetworkInterfaceService
{
    public bool IsNetworkAvailable()
    {
        return NetworkInterface.GetIsNetworkAvailable();
    }

    public NetworkInterface[] GetAllNetworkAdapters()
    {
        return NetworkInterface.GetAllNetworkInterfaces();
    }

    public NetworkInterface? GetAdapterByName(string adapterName)
    {
        return GetAllNetworkAdapters().FirstOrDefault(a => a.Name == adapterName);
    }
}
