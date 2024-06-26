﻿using System.Net.NetworkInformation;

namespace NetworkConfigLibrary;

public class NetworkDetailsFormatter : INetworkDetailsFormatter
{
    public string FormatAdapterDetails(NetworkInterface? adapter)
    {
        var details = $"Adapter Name: {adapter?.Name}\n";
        details += $"Status: {adapter?.OperationalStatus}\n";
        details += $"Adapter Type: {adapter?.NetworkInterfaceType}\n";

        if (adapter?.OperationalStatus == OperationalStatus.Up)
        {
            var ipProperties = adapter.GetIPProperties();
            details += FormatIpProperties(ipProperties);
        }
        else
        {
            details += "Adapter is not connected.\n";
        }

        return details;
    }

    private static string FormatIpProperties(IPInterfaceProperties ipProperties)
    {
        var details = string.Empty;
        var ipv4 = ipProperties.UnicastAddresses.FirstOrDefault(ip =>
            ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
        );
        var ipv6 = ipProperties.UnicastAddresses.FirstOrDefault(ip =>
            ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6
        );

        details += $"IPv4 Address: {ipv4?.Address}\n";
        details += $"IPv4 Subnet Mask: {ipv4?.IPv4Mask}\n";

        details += $"IPv6 Address: {ipv6?.Address}\n";

        var gatewayAddresses = ipProperties.GatewayAddresses.Select(g => g.Address).ToList();
        if (gatewayAddresses.Count > 0)
        {
            details += $"Gateway Addresses: {string.Join(", ", gatewayAddresses)}\n";
        }
        else
        {
            details += "No Gateway Addresses assigned.\n";
        }

        var dnsAddresses = ipProperties.DnsAddresses;
        if (dnsAddresses.Count > 0)
        {
            details += $"DNS Servers: {string.Join(", ", dnsAddresses)}\n";
        }
        else
        {
            details += "No DNS Servers assigned.\n";
        }

        return details;
    }
}
