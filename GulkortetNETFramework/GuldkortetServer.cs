using System;
using System.Drawing;
using System.Windows.Forms;
using GulkortetNETFramework.Services.Interfaces;
// ReSharper disable LocalizableElement

namespace GulkortetNETFramework
{
    public partial class GuldkortetServer : Form
    {
        private readonly ITcpServer _tcpServer;

        // CTOR som tar in en ITcpServer som DI
        public GuldkortetServer(ITcpServer tcpServer)
        {
            // Try Catch för att det inte ska krascha
            try
            {
                _tcpServer = tcpServer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            InitializeComponent();
            MessageView.View = View.Details;
            MessageView.Columns.Add("Resultat").Width = 50;
            MessageView.Columns.Add("Kortnummer").Width = 80;
            MessageView.Columns.Add("Användare").Width = 80;
            MessageView.Columns.Add("Svar").Width = 1000;
        }

        // Startar servern med ett klick
        private async void StartServer_Click(object sender, EventArgs e)
        {
            // Tilldelar lite properties till knappen
            StartServer.Enabled = false;
            StartServer.BackColor = Color.Green;
            StartServer.Text = "Server Started";


            // Try Catch för att det inte ska krascha
            try
            {
                // Startar servern, kastar även in MessageView för att kunna skriva till GUIn
                await _tcpServer.StartServer(MessageView);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);

                // Tilldelar lite properties till knappen
                StartServer.Enabled = true;
                StartServer.BackColor = Color.Red;
                StartServer.Text = "Start Server";
            }
           
        }
    }
}