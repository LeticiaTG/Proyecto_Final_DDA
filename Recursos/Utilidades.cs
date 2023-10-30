using System.Security.Cryptography;
using System.Text;

namespace Proyecto_Final_DDA.Recursos
{
    public class Utilidades
    {
        public static String EncriptarClave(String clave)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(clave));

                foreach (byte b in result) 
                    sb.Append(b.ToString("x2"));
            } 

            return sb.ToString();
        }
    }
}
