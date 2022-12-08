namespace EjemploSignalR.Models
{
    public class Pais
    {
        public string Nombre { get; set; }
        public int CantidadJugadores { get; set; }
        public bool EsMundialista
        {
            get
            {
                return new Random().Next(0, 2) == 1 ? true : false;
            }
        }
    }
}
