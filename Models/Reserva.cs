namespace EjemploDeApi.Models;

public class Reserva
{
    public int Id { get; set; }
    public int IdRestaurante { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int CantidadPersonas { get; set; }
    public Restaurante? Restaurante { get; set; }
}