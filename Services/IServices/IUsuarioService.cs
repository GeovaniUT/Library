using Biblioteca_Guzman_Geovani.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Guzman_Geovani.Services.IServices
{
    public interface IUsuarioService
    {

        public List<Usuario> ObtenerUsuarios();

        public bool CrearUsuario(Usuario request);

        public Usuario GetUsuarioById(int id);

        public bool EditarUsuario(Usuario usuario);

        public bool Eliminar(int id);






    }
}
