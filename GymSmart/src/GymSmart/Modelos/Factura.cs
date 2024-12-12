// Esta clase es para: Gestionar la información de las facturas generadas por las membresías y otras transacciones.
public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaEmision { get; set; }
    public decimal Monto { get; set; }
}
