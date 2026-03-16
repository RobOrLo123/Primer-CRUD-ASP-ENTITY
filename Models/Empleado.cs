namespace CRUDASP.Models
{
    public class Empleado
    {

        public string Cedula { get; set; }

        public string NombreCompleto { get; set; }

        public string correo { get; set; }

        public string password { get; set; }

        public DateOnly FechaContrato { get; set; }

        public bool activo { get; set; }

        public bool administrador { get; set; }

    }
}
