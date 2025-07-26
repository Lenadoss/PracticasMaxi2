using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioo;
using System.Data.SqlClient;

namespace negocioo
{
    public class NegocioGenero
    {
        public List<Genero> listar()
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Genero> lista = new List<Genero>();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=PELICULAS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT id, descripcion FROM GENEROS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				while(lector.Read())
				{
					Genero aux = new Genero();
					aux.Id = (int)lector["id"];
					aux.Descripcion = (string)lector["descripcion"];
					lista.Add(aux);
				}
				lector?.Close();
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conexion.Close();
			}
        }
    }
}
