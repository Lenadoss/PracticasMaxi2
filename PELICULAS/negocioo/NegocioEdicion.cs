using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominioo;

namespace negocioo
{
    public class NegocioEdicion
    {
		public List<Edicion> listar()
		{
            SqlDataReader lector;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<Edicion> lista = new List<Edicion>();
            try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=PELICULAS_DB; integrated security = true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT id, descripcion FROM TIPOSEDICION";
				conexion.Open();
				comando.Connection = conexion;
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Edicion aux = new Edicion();
					aux.Id = (int)lector["id"];
					aux.Descripcion = (string)lector["descripcion"];
					lista.Add(aux);
				}
                if (lector != null)
                    lector.Close();
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
