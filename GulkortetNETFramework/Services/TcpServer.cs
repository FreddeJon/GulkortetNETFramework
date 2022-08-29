using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GulkortetNETFramework.Services.Interfaces;

namespace GulkortetNETFramework.Services
{
    public class TcpServer : ITcpServer
    {
        // 2 consts IpAdress och port
        private const string IpAdress = "127.0.0.1";
        private const int Port = 12345;

        // Några properties
        private readonly IIncomingDataValidator _incomingDataValidator;

        private readonly TcpListener _listener;
        private ListView _messageView;
        private TcpClient _tcpClient;


        // CTOR, tar in en IIncomingDataValidator med DI
        public TcpServer(IIncomingDataValidator incomingDataValidator)
        {
            _incomingDataValidator = incomingDataValidator;

            // Try Catch för att det inte ska krascha
            try
            {
                // Skapar upp en tcpListener beroende på ipadress och port
                _listener = new TcpListener(IPAddress.Parse(IpAdress), Port);
            }
            catch
            {
                // Throws error om det går fel
                throw new Exception("Internal error");
            }
        }


        // En metod för att starta servern och börja lyssna och ta emot requests, tar in en ListView för att kunna lägga till saker i den i GUI
        public async Task StartServer(ListView messageView)
        {
            _messageView = messageView;

            // Try Catch För att det inte ska krascha, skickar tillbaka felet om det går snett.
            try
            {
                // Börjar lyssna efter inkommande connections
                _listener.Start();

                // Tar emot inkommande connections
                _tcpClient = await _listener.AcceptTcpClientAsync();
            }
            catch
            {
                // Throws error om det går fel
                throw new Exception("Internal error");
            }
            // Läser streamen
            ReadStream();
        }

        // En recursive funktion som fortsätter lyssna tills att programmet stängs
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public async void ReadStream()
        {
            var data = new byte[1024];
            var n = 0;
            
            // TryCatch för att det inte ska krascha
            try
            {
                // Tar emot en stream och tilldelar byte[] till buffert
                n = await _tcpClient.GetStream().ReadAsync(data, n, data.Length);
            }
            catch
            {
                // ignored
            }

            // byte[] data decodas till en string
            var incomingMessage = Encoding.Unicode.GetString(data, 0, n);


            // Skickar in stringen i validatorn och får tillbaka en response
            var validatorResponse = await _incomingDataValidator.Validate(incomingMessage);


            // Lägger in responsen i ListView i GUIn med olika värden beroende på responsen
            _messageView.Items.Add(new ListViewItem(new[]
            {
                validatorResponse.IsValid ? "Vinst" : "Förlust",
                validatorResponse.Card?.KortNr ?? "N/A",
                validatorResponse.User?.AnvändarNr ?? "N/A",
                validatorResponse.IsValid ? validatorResponse.ToString() : validatorResponse.Message
            }));

            // Skriver tillbaka ett meddelande till clienten
            await WriteToStream(validatorResponse.ToString());

            ReadStream();
        }

        // En metod som skickar tillbaka ett meddelande till clienten
        public async Task WriteToStream(string message)
        {
            // TryCatch för att det inte ska krascha
            try
            {
                // Skapar en byte[] av meddelandet
                var data = Encoding.Unicode.GetBytes(message);

                // Skriver till streamen
                await _tcpClient.GetStream().WriteAsync(data, 0, data.Length);
            }
            catch
            {
                // ignored
            }
        }
    }
}