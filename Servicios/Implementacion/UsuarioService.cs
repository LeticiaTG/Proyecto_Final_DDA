using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DDA.Models;
using Proyecto_Final_DDA.Servicios;
using Proyecto_Final_DDA.Servicios.Contrato;

namespace Proyecto_Final_DDA.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        //Estos Slash y astericos son comentario recuerden eliminarlos 
        //para que la pagina funcione, como aun no me se el nombre de la base de datos
        //lo puse asi :D
   

        /*private readonly 'Aqui va nombre de la base de datos sin comillas'_dbContext.
          
         public UsuarioImple('Aqui va nombre de bd' dbContext)
        {
         _dbContext = dbContext;   
        }
         */
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await_dbContext.Usuarios.Where(u =>u.Correo==correo && u.Clave==clave)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public Task<Usuario> SaveUsuario(Usuario modelo)
        {
            /*dbContext.Usuarios.Add(modelo);
            
            await_dbContext.SaveChangesAsync();
            return modelo;
              
             */

        }
    }
}
