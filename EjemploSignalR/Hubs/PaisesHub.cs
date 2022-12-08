using EjemploSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace EjemploSignalR.Hubs
{
    public class PaisesHub : Hub    
    {
        public async Task EnviarMensaje(Pais pais)
        {
            await Clients.All.SendAsync("ReceiveResult", pais.Nombre, pais.CantidadJugadores, pais.EsMundialista);
        }
    }
}
