namespace DepilZone.Entidad.DTO
{
    public class ChatUsuarioListaDTO
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int MensajeSinLeer { get; set; }
        public string Foto { get; set; }
        public string UltimaConexion { get; set; }
        public int Estado { get; set; }
    }
}
