using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public class NetworkToolManager(
    INetworkInterfaceService networkInterfaceService,
    INetworkDetailsFormatter networkDetailsFormatter
) : INetworkToolManager
{
    public bool IsNetworkAvailable()
    {
        return networkInterfaceService.IsNetworkAvailable();
    }

    public NetworkInterface[] GetAllNetworkAdapters()
    {
        return networkInterfaceService.GetAllNetworkAdapters();
    }

    public string GetNetworkConfiguration(string adapterName)
    {
        var adapter = networkInterfaceService.GetAdapterByName(adapterName);
        return adapter is null
            ? $"Error: Adapter '{adapterName}' not found."
            : networkDetailsFormatter.FormatAdapterDetails(adapter);
    }
}
