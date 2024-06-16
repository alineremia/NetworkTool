using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public interface INetworkDetailsFormatter
{
    string FormatAdapterDetails(NetworkInterface? adapter);
}
