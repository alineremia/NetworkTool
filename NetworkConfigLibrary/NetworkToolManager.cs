using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public class NetworkToolManager
{
    public NetworkInterface[] GetAllNetworkAdapters()
    {
        return NetworkInterface.GetAllNetworkInterfaces();
    }

    public string GetNetworkConfiguration(string adapterName)
    {
        var adapter = GetAllNetworkAdapters().FirstOrDefault(a => a.Name == adapterName);
        if (adapter is null)
            return "Adapter not found.";

        var details = $"Adapter Name: {adapter.Name}\n";
        details += $"Status: {adapter.OperationalStatus}\n";

        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
            var ipProperties = adapter.GetIPProperties();
            var ipv4 = ipProperties.UnicastAddresses.FirstOrDefault(ip =>
                ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
            );
            var ipv6 = ipProperties.UnicastAddresses.FirstOrDefault(ip =>
                ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
            );

            if (ipv4 is not null)
            {
                details += $"IPv4 Address: {ipv4.Address}\n";
                details += $"IPv4 Subnet Mask: {ipv4.IPv4Mask}\n";
            }
            else
            {
                details += "No IPv4 Address assigned.\n";
            }

            if (ipv6 is not null)
            {
                details += $"IPv6 Address: {ipv6.Address}\n";
            }
            else
            {
                details += "No IPv6 Address assigned.\n";
            }

            var gatewayAddresses = ipProperties.GatewayAddresses.Select(g => g.Address).ToList();
            if (gatewayAddresses.Any())
            {
                details += $"Gateway Addresses: {string.Join(", ", gatewayAddresses)}\n";
            }
            else
            {
                details += "No Gateway Addresses assigned.\n";
            }

            var dnsAddresses = ipProperties.DnsAddresses;
            if (dnsAddresses.Any())
            {
                details += $"DNS Servers: {string.Join(", ", dnsAddresses)}\n";
            }
            else
            {
                details += "No DNS Servers assigned.\n";
            }
        }
        else
        {
            details += "Adapter is not connected.\n";
        }

        return details;
    }

    public bool IsNetworkAvailable()
    {
        return NetworkInterface.GetIsNetworkAvailable();
    }
}
