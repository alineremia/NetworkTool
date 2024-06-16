using Autofac;
using NetworkConfigLibrary;

namespace NetworkTool;

public static class DependencyInjectionConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<NetworkToolManager>().As<INetworkToolManager>();
        builder.RegisterType<NetworkInterfaceService>().As<INetworkInterfaceService>();
        builder.RegisterType<NetworkDetailsFormatter>().As<INetworkDetailsFormatter>();

        builder.RegisterType<MainForm>();

        return builder.Build();
    }
}
