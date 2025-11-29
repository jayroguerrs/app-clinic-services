namespace DepilZone.Entidad.DTO
{

    public class ShortUser
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class UsuarioGridDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public int IdEstado { get; set; }
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public string UsuarioRegistra { get; set; }
        public string FechaRegistra { get; set; }
        public bool? ClaveGenrica { get; set; }


        // para NgSelect de Angular
        public string value
        {
            get
            {
                return IdUsuario.ToString();
            }
        }
        public string label
        {
            get
            {
                return Nombre + " | " + Usuario;
            }
        }

        public string Foto { get; set; }

    }


    /*public class UsuarioCambiarClaveDTO
    {
        public string Clave { get; set; }
    }
    */

}
