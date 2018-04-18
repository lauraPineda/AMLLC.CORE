using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AMLLC.CORE.SHARED
{
    public class HashEncryption
    {
        /// <summary>
        /// Transforma el texto enviado una salida alfanumérica de longitud fija
        /// que representa un resumen de toda la información que se le ha dado
        /// </summary>
        /// <param name="textoPlano">Texto a transformar</param>
        /// <returns>Texto transformado</returns>
        public static string Hash(string textoPlano)
        {
            byte[] salt;
            byte[] buffer;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(textoPlano, 16, 1000))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(32);
            }
            byte[] dst = new byte[49];
            Buffer.BlockCopy(salt, 0, dst, 1, 16);
            Buffer.BlockCopy(buffer, 0, dst, 17, 32);

            return Convert.ToBase64String(dst);
        }

        /// <summary>
        /// COmpara que las contraseñas sean iguales
        /// </summary>
        /// <param name="hashedPassword">Contraseña transformada</param>
        /// <param name="password">Contraseña a comparar</param>
        /// <returns>Resultado de la comparacion de las contraseñas</returns>
        public static bool VerifyHashPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            byte[] src = Convert.FromBase64String(hashedPassword);

            byte[] dst = new byte[16];
            Buffer.BlockCopy(src, 1, dst, 0, 16);
            byte[] buffer3 = new byte[32];
            Buffer.BlockCopy(src, 17, buffer3, 0, 32);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 1000))
            {
                buffer4 = bytes.GetBytes(32);
            }
            return buffer3.SequenceEqual(buffer4);

        }
    }
}
