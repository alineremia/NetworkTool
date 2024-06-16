using NetworkConfigLibrary;
using Timer = System.Windows.Forms.Timer;

namespace NetworkTool;

public partial class MainForm : Form
{
    private readonly INetworkToolManager _networkToolManager;
    private Timer? _networkCheckTimer;

    public MainForm(INetworkToolManager networkToolManager)
    {
        _networkToolManager = networkToolManager;
        InitializeComponent();

        InitializeTimer();
        LoadNetworkAdapters();
        UpdateNetworkAvailability();
    }

    private void LoadNetworkAdapters()
    {
        listBoxAdapters.Items.Clear();
        var adapters = _networkToolManager.GetAllNetworkAdapters();
        foreach (var adapter in adapters)
        {
            listBoxAdapters.Items.Add(adapter.Name);
        }
    }

    private void InitializeTimer()
    {
        _networkCheckTimer = new Timer();
        _networkCheckTimer.Interval = 100;
        _networkCheckTimer.Tick += NetworkCheckTimer_Tick;
        _networkCheckTimer.Start();
    }

    private void NetworkCheckTimer_Tick(object? sender, EventArgs e)
    {
        UpdateNetworkAvailability();
    }

    private bool UpdateNetworkAvailability()
    {
        if (CheckNetworkAndPrompt())
        {
            pictureBoxNetworkStatus.BackColor = Color.Green;
            return true;
        }

        pictureBoxNetworkStatus.BackColor = Color.Red;
        return false;
    }

    private void DisplayNetworkConfiguration(string adapterName)
    {
        textBoxDetails.Clear();
        textBoxDetails.Text = _networkToolManager.GetNetworkConfiguration(adapterName);
    }

    private bool CheckNetworkAndPrompt()
    {
        if (_networkToolManager.IsNetworkAvailable())
            return true;
        textBoxDetails.Text =
            @"The network is not available. Please connect and click the refresh button";
        return false;
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
        if (!UpdateNetworkAvailability())
            return;
        LoadNetworkAdapters();
    }

    private void listBoxAdapters_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!UpdateNetworkAvailability())
            return;
        var selectedAdapter = listBoxAdapters.SelectedItem?.ToString();
        if (selectedAdapter is not null)
            DisplayNetworkConfiguration(selectedAdapter);
    }
}
