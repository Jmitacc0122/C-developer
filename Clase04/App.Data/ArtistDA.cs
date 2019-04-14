using App.Entidades;
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

        public List<Artist> GetAll(string filterByName ="")//parametro opcional
        {
            var result = new List<Artist>();

            var sql = "SELECT * FROM Artist where name like @ParamFilterByName";
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                /* Creando el objeto comand*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); // Abriendo la conexion a la base de datos
                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(new SqlParameter("@ParamFilterByName", filterByName));
                var Reader = cmd.ExecuteReader();
                var indice = 0;
                while(Reader.Read())
                {
                    var Artista = new Artist();
                    indice = Reader.GetOrdinal("ArtistId");

                    Artista.ArtisId = Reader.GetInt32(indice);

                    indice = Reader.GetOrdinal("Name");
                    Artista.Name = Reader.GetString(indice);

                    result.Add(Artista);
                }
                return result;
            }
        }

        public Artist Get(int Id)
        {
            var result = new Artist();
            var sql = "SELECT * FROM Artist where ArtistId=1";
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                /* Creando el objeto comand*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); // Abriendo la conexion a la base de datos
                /* Configurando los parametros*/
                cmd.Parameters.Add(
                    new SqlParameter("@ParameterId", Id)
                 );
                var Reader = cmd.ExecuteReader();
                var indice = 0;
                while (Reader.Read())
                {
                    indice = Reader.GetOrdinal("ArtistId");
                    

                    indice = Reader.GetOrdinal("Name");

                }
            }

                return result;
        }

        public List<Artist> GetAllSP(string filterByName = "")//parametro opcional
        {
            var result = new List<Artist>();

            var sql = "SP_GetAll";
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                /* Creando el objeto comand*/
                IDbCommand cmd = new SqlCommand(sql);
                /* Indicar que ahora es un procedimiento almacenado*/
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open(); // Abriendo la conexion a la base de datos
                filterByName = $"%{filterByName}%";
                cmd.Parameters.Add(new SqlParameter("@filterByName", filterByName));
                var Reader = cmd.ExecuteReader();
                var indice = 0;
                while (Reader.Read())
                {
                    var Artista = new Artist();
                    indice = Reader.GetOrdinal("ArtistId");

                    Artista.ArtisId = Reader.GetInt32(indice);

                    indice = Reader.GetOrdinal("Name");
                    Artista.Name = Reader.GetString(indice);

                    result.Add(Artista);
                }
                return result;
            }
        }
    }
}
