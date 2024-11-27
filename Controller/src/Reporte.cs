// Esta clase es para: Gestionar la generación de reportes.
public class Reporte
{
    public int Id { get; set; }
    public string Tipo { get; set; } // Ejemplo: "Matrícula", "Informe Contable", "Clases Populares"
    public DateTime FechaGeneracion { get; set; }
    public string Contenido { get; set; }
}
