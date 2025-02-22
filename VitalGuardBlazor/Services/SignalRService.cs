using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace VitalGuardBlazor.Services
{
    public class SignalRService
    {
        private readonly HubConnection _hubConnection;

        public SignalRService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        public async Task StartConnection()
        {
            try
            {
                await _hubConnection.StartAsync();
                Console.WriteLine("SignalR connected.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to SignalR: {ex.Message}");
            }
        }

        public async Task StopConnection()
        {
            await _hubConnection.StopAsync();
            Console.WriteLine("SignalR disconnected.");
        }

        // This method sends updates to the SignalR hub
        public async Task SendPatientUpdate(string patientId, string message)
        {
            await _hubConnection.SendAsync("ReceivePatientUpdate", patientId, message);
        
        }
        
        // This method listens for patient updates from the SignalR hub
        public void OnPatientUpdate(Func<string, string, Task> handler)
        {
            _hubConnection.On<string, string>("ReceivePatientUpdate", handler);
        }

    }
}
