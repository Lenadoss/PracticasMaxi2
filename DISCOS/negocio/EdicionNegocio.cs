using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class EdicionNegocio
    {
        public List<Edicion> listar ()
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Edicion> lista = new List<Edicion>();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=DISCOS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "Select id,descripcion FROM TIPOSEDICION";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Edicion aux = new Edicion();
					aux.Id = (int)lector["id"];
					aux.Descripcion = (string)lector["descripcion"];
					lista.Add(aux);
				}

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
