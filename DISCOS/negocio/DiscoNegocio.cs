using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
	public class DiscoNegocio
	{
		public List<Disco> Listar()
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Disco> lista = new List<Disco>();

			try
			{
				conexion.ConnectionString = "server = (localdb)\\MSSQLlocalDB ; database = DISCOS_DB; integrated security = true; ";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT d.id, d.titulo, d.fechalanzamiento, d.cantidadcanciones, d.urlimagentapa, e.descripcion Estilo, te.descripcion Edicion FROM discos d, estilos e, tiposedicion te WHERE idestilo = e.id AND idtipoedicion = te.id";
				comando.Connection = conexion;
                conexion.Open();
				lector = comando.ExecuteReader();

				while(lector.Read())
				{
					Disco aux = new Disco();
					aux.Id = (int)lector["id"];
					aux.Titulo = (string)lector["titulo"];
					aux.FechaLanzamiento = (DateTime)lector["fechalanzamiento"];
					aux.CantidadCanciones = (int)lector["CantidadCanciones"];
					aux.UrlImagenTapa = (string)lector["urlimagentapa"];
					aux.Estilo = new Estilo();
					aux.Estilo.Descripcion = (string)lector["Estilo"];
					aux.Edicion = new Edicion();
					aux.Edicion.Descripcion = (string)lector["Edicion"];
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



