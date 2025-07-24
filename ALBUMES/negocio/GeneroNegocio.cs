using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class GeneroNegocio
    {
        public List<Genero> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Genero> lista = new List<Genero>();

            try
            {

                conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=ALBUMES_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Descripcion FROM GENEROS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                
                while (lector.Read())
                {

                    Genero aux = new Genero();
                    aux.Id = (int)lector["Id"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    lista.Add(aux);

                }

                return lista;
                
            }
            catch (Exception ex)
            {    
                throw ex;
            }

        }
    }
}
