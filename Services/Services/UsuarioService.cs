using Biblioteca_Guzman_Geovani.Context;
using Biblioteca_Guzman_Geovani.Models.Domain;
using Biblioteca_Guzman_Geovani.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Guzman_Geovani.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        //funcion para obtener lista de usuarios
        public List<Usuario> ObtenerUsuarios()
        {
        
            try
            {
                List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public bool CrearUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {

                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol  = 1,
                };

                _context.Usuarios.Add(usuario);
               int result = _context.SaveChanges();
                if (result > 0) { 
                    return true;
                }

                return false;


               
            }

            catch (Exception ex) {

                throw new Exception("Sucedio un error:" + ex.Message);
            }
        
        }
        public Usuario GetUsuarioById(int id)
        {
            try
            {
                Usuario result = _context.Usuarios.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioExistente = _context.Usuarios.Find(usuario.PkUssario);

                 if (usuarioExistente == null)
                {
                    return false; 
                }

                
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.UserName = usuario.UserName;
                usuarioExistente.Password = usuario.Password;
                //usuarioExistente.Roles = 1; 

                _context.Usuarios.Update(usuarioExistente);
                _context.SaveChanges();

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar usuario: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);

                if (usuario == null)
                {
                    return false; 
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message);
            }
        }


    }
}
