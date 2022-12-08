using EjemploSignalR.Hubs;
using EjemploSignalR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EjemploSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private IHubContext<PaisesHub> hubContext;

        public PaisController(IHubContext<PaisesHub> hubContext)
        {
            this.hubContext = hubContext;
        }


        [HttpPost]
        public async Task<IActionResult> AgregarPais(Pais pais)
        {
            if(pais is not null)
            {
                await hubContext.Clients.All.SendAsync("ReceiveResult", pais.Nombre, pais.CantidadJugadores, pais.EsMundialista);
                return Ok(pais);
            }

            return BadRequest();
        }
    }
}
