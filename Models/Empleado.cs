namespace CRUDASP.Models
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }

        public string NombreCompleto { get; set; }

        public string correo { get; set; }

        public DateOnly FechaIngreso { get; set; }

        public bool activo { get; set; }

    }
}
