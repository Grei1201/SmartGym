using System.Collections.Generic;

// Esta clase es para: Representar a los entrenadores del gimnasio.
public class Entrenador : Usuario
{
    // Lista de puntos fuertes del entrenador, como especialidades o habilidades.
    public List<string> PuntosFuertes { get; set; }

    // Lista de horarios en los que el entrenador está disponible.
    public List<string> Horarios { get; set; }

    // Constructor que establece el rol del entrenador.
    public Entrenador()
    {
        Rol = "Entrenador";
    }

    // Método para obtener una cadena de texto con la información del entrenador.
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre} {Apellido}, " +
               $"Puntos Fuertes: {string.Join(", ", PuntosFuertes)}, " +
               $"Horarios: {string.Join(", ", Horarios)}";
    }
}
