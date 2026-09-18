namespace EjemploDeApi.Models;

public class Restaurante
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}