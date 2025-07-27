using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class AlbumNegocio
    {
        public List<Album> listar()
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Album> lista = new List<Album>();

			try
			{

				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = ALBUMES_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT a.id, a.titulo, a.fechalanzamiento, a.urlimagencover, g.descripcion GENERO, te.descripcion EDICION, a.idgenero, a.idtipoedicion FROM ALBUMES a, GENEROS g, TIPOSEDICION te WHERE a.idgenero = g.id AND a.idtipoedicion = te.id AND Activo = 1;";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				while(lector.Read())
				{
					Album aux = new Album();
					aux.Id = (int)lector["id"];
					aux.Titulo = (string)lector["titulo"];
					aux.FechaLanzamiento = (DateTime)lector["fechalanzamiento"];
					aux.UrlImagenCover = (string)lector["urlimagencover"];
					aux.Genero = new Genero();
					aux.Genero.Id = (int)lector["idgenero"];
					aux.Genero.Descripcion = (string)lector["GENERO"];
					aux.Edicion = new Edicion();
					aux.Edicion.Id = (int)lector["idtipoedicion"];
					aux.Edicion.Descripcion = (string)lector["EDICION"];

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

		public void Agregar(Album AlbumNuevo)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();

			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = ALBUMES_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT INTO ALBUMES (titulo, fechalanzamiento, urlimagencover, idgenero, idtipoedicion) VALUES (@titulo, @fecha, @url, @idgenero, @idtipoedicion)";
				comando.Parameters.AddWithValue("titulo", AlbumNuevo.Titulo);
                comando.Parameters.AddWithValue("fecha", AlbumNuevo.FechaLanzamiento);
                comando.Parameters.AddWithValue("url", AlbumNuevo.UrlImagenCover);
                comando.Parameters.AddWithValue("idgenero", AlbumNuevo.Genero.Id);
                comando.Parameters.AddWithValue("idtipoedicion", AlbumNuevo.Edicion.Id);
				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();
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

        public void Modificar(Album album)
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=ALBUMES_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE ALBUMES SET titulo = @titulo, fechalanzamiento = @fecha , urlimagencover = @url, idgenero = @idgenero, idtipoedicion = @idtipoedicion WHERE id = @id ;";
				comando.Parameters.AddWithValue("titulo",album.Titulo);
                comando.Parameters.AddWithValue("fecha",album.FechaLanzamiento);
                comando.Parameters.AddWithValue("url",album.UrlImagenCover);
                comando.Parameters.AddWithValue("idgenero",album.Genero.Id);
                comando.Parameters.AddWithValue("idtipoedicion",album.Edicion.Id);
                comando.Parameters.AddWithValue("id",album.Id);
                comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();
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

        public void Eliminar(int id)
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = ALBUMES_DB; integrated security = true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "DELETE FROM ALBUMES WHERE ID = @id";
				comando.Parameters.AddWithValue("id", id);
				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();
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

        public void EliminarLogico(int id)
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = ALBUMES_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE ALBUMES SET ACTIVO = 0 WHERE ID = @id";
				comando.Parameters.AddWithValue("id", id);
				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();
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
