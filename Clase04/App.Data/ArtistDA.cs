using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class ArtistDA: BaseConnection
    {
        // ADO.NET
        public int GetCount()
        {
            /// <summary>
            /// Permite obtener la cantidad de registro que existe en la tabla Artist
            /// </summary>
            /// <returns> Retorna el numero de registos</returns>
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /*Creando la instancia del objeto conection*/
            using (IDbConnection cn= new SqlConnection (this.ConnectionString))
            {
                /* Creando el objeto comand*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); // Abriendo la conexion a la base de datos

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            /*El usgin cierra la coneccion una vez finalice el proceso*/
                return result;
        }
    }
}
