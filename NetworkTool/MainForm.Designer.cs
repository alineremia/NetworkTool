namespace NetworkTool;
partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        listBoxAdapters = new ListBox();
        buttonRefresh = new Button();
        textBoxDetails = new RichTextBox();
        pictureBoxNetworkStatus = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBoxNetworkStatus).BeginInit();
        SuspendLayout();
        // 
        // listBoxAdapters
        // 
        listBoxAdapters.FormattingEnabled = true;
        listBoxAdapters.ItemHeight = 15;
        listBoxAdapters.Location = new Point(12, 12);
        listBoxAdapters.Name = "listBoxAdapters";
        listBoxAdapters.Size = new Size(698, 169);
        listBoxAdapters.TabIndex = 0;
        listBoxAdapters.SelectedIndexChanged += listBoxAdapters_SelectedIndexChanged;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonRefresh.Location = new Point(745, 12);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(125, 23);
        buttonRefresh.TabIndex = 1;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += buttonRefresh_Click;
        // 
        // textBoxDetails
        // 
        textBoxDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        textBoxDetails.Location = new Point(12, 187);
        textBoxDetails.Name = "textBoxDetails";
        textBoxDetails.ReadOnly = true;
        textBoxDetails.Size = new Size(858, 175);
        textBoxDetails.TabIndex = 2;
        textBoxDetails.Text = "";
        // 
        // pictureBoxNetworkStatus
        // 
        pictureBoxNetworkStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        pictureBoxNetworkStatus.Location = new Point(716, 12);
        pictureBoxNetworkStatus.Name = "pictureBoxNetworkStatus";
        pictureBoxNetworkStatus.Size = new Size(23, 22);
        pictureBoxNetworkStatus.TabIndex = 3;
        pictureBoxNetworkStatus.TabStop = false;
        // 
        // MainForm
        // 
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(882, 374);
        Controls.Add(pictureBoxNetworkStatus);
        Controls.Add(textBoxDetails);
        Controls.Add(buttonRefresh);
        Controls.Add(listBoxAdapters);
        Name = "NetworkTool";
        Text = "Network Tool";
        ((System.ComponentModel.ISupportInitialize)pictureBoxNetworkStatus).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBoxAdapters;
    private System.Windows.Forms.Button buttonRefresh;
    private System.Windows.Forms.RichTextBox textBoxDetails;
    private System.Windows.Forms.PictureBox pictureBoxNetworkStatus;
}