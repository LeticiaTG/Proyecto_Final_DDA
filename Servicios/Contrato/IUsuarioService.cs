using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DDA.Models;


namespace Proyecto_Final_DDA.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario>GetUsuario(string correo, string clave);

        Task<Usuario>SaveUsuario(Usuario modelo);
    }
}
