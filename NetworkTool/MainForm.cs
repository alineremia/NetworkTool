using NetworkConfigLibrary;

namespace NetworkTool;

public partial class MainForm : Form
{
    private readonly NetworkToolManager _networkToolManager;

    public MainForm()
    {
        InitializeComponent();
        _networkToolManager = new NetworkToolManager();
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

    private void UpdateNetworkAvailability()
    {
        pictureBoxNetworkStatus.BackColor = _networkToolManager.IsNetworkAvailable()
            ? Color.Green
            : Color.Red;
    }

    private void DisplayNetworkConfiguration(string adapterName)
    {
        var details = _networkToolManager.GetNetworkConfiguration(adapterName);
        textBoxDetails.Text = details;
    }

    private void CheckNetworkAndPrompt()
    {
        if (!_networkToolManager.IsNetworkAvailable())
        {
            textBoxDetails.Text =
                @"The network is not available. Please connect and click the refresh button";
        }
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
        CheckNetworkAndPrompt();
        LoadNetworkAdapters();
        UpdateNetworkAvailability();
    }

    private void listBoxAdapters_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckNetworkAndPrompt();
        var selectedAdapter = listBoxAdapters.SelectedItem?.ToString();
        if (selectedAdapter is not null)
            DisplayNetworkConfiguration(selectedAdapter);
    }
}
