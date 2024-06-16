using System.Net.NetworkInformation;

namespace NetworkConfigLibrary.Test;

[TestFixture]
public class NetworkToolManagerTests
{
    private NetworkToolManager _networkToolManager;

    [SetUp]
    public void Setup()
    {
        _networkToolManager = new NetworkToolManager(
            new NetworkInterfaceService(),
            new NetworkDetailsFormatter()
        );
    }

    [Test]
    public void GetAllNetworkAdapters_ShouldReturnAdapters()
    {
        // Act
        var adapters = _networkToolManager.GetAllNetworkAdapters();

        // Assert
        Assert.IsNotNull(adapters);
        Assert.IsInstanceOf<NetworkInterface[]>(adapters);
        Assert.IsTrue(adapters.Length > 0);
    }

    [Test]
    public void IsNetworkAvailable_ShouldReturnBoolean()
    {
        // Act
        var isAvailable = _networkToolManager.IsNetworkAvailable();

        // Assert
        Assert.IsInstanceOf<bool>(isAvailable);
    }

    [Test]
    public void GetNetworkConfiguration_NonexistentAdapter_ShouldReturnErrorMessage()
    {
        //Setup
        var adapterName = "Nonexistent Adapter";

        // Act
        var details = _networkToolManager.GetNetworkConfiguration(adapterName);

        // Assert
        Assert.AreEqual($"Error: Adapter '{adapterName}' not found.", details);
    }

    [Test]
    public void GetNetworkConfiguration_ExistingAdapter_ShouldReturnDetails()
    {
        // Setup
        var adapter = _networkToolManager.GetAllNetworkAdapters().FirstOrDefault();

        if (adapter is null)
        {
            Assert.Ignore("No network adapters available for testing.");
        }

        // Act
        var details = _networkToolManager.GetNetworkConfiguration(adapter.Name);

        // Assert
        Assert.IsNotEmpty(details);
        Assert.IsTrue(details.Contains($"Adapter Name: {adapter.Name}"));
    }

    [Test]
    public void FormatIpProperties_ValidIPProperties_ShouldReturnFormattedString()
    {
        //Setup
        var adapter = _networkToolManager.GetAllNetworkAdapters().FirstOrDefault();

        if (adapter is null)
        {
            Assert.Ignore("No network adapters available for testing.");
        }

        //Act
        var details = _networkToolManager.GetNetworkConfiguration(adapter.Name);

        //Assert
        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
            Assert.IsTrue(
                details.Contains("IPv4 Address") || details.Contains("No IPv4 Address assigned")
            );
            Assert.IsTrue(
                details.Contains("IPv6 Address") || details.Contains("No IPv6 Address assigned")
            );
            Assert.IsTrue(
                details.Contains("Gateway Addresses")
                    || details.Contains("No Gateway Addresses assigned")
            );
            Assert.IsTrue(
                details.Contains("DNS Servers") || details.Contains("No DNS Servers assigned")
            );
        }
    }
}
