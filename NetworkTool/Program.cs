using Autofac;

namespace NetworkTool;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var container = DependencyInjectionConfig.Configure();
        using var scope = container.BeginLifetimeScope();
        var mainForm = scope.Resolve<MainForm>();
        Application.Run(mainForm);
    }
}
