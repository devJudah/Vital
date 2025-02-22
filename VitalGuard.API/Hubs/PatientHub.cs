// Hubs/PatientHub.cs
using Microsoft.AspNetCore.SignalR;

namespace VitalGuard.API.Hubs{

    public class PatientHub : Hub
    {
        // This method can be called from the client to broadcast messages to all connected clients.
        public async Task SendPatientUpdate(string patientId, string updateMessage)
        {
            await Clients.All.SendAsync("ReceivePatientUpdate", patientId, updateMessage);
        }
    }
}
