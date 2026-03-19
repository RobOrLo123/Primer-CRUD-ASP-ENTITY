namespace CRUDASP.ViewModels
{
    public class UsuarioVM
    {

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string correo { get; set; }

        public string password { get; set; }

        public string Confirmarpassword { get; set; }

        public bool activo { get; set; }

        public bool administrador { get; set; }

    }
}
