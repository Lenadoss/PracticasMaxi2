using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioo;
using System.Data.SqlClient;

namespace negocioo
{
    public class NegocioPelicula
    {
        public List<Pelicula> listar()
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Pelicula> lista = new List<Pelicula>();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=PELICULAS_DB; integrated security = true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT p.id, p.titulo, p.fechalanzamiento, p.urlimagen, p.idgenero, p.idtipoedicion, g.descripcion Genero, te.descripcion Edicion FROM PELICULAS p, GENEROS g, TIPOSEDICION te WHERE p.idgenero = g.id AND p.idtipoedicion = te.id;";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();
				while(lector.Read())
				{
					Pelicula aux = new Pelicula();
					aux.Id = (int)lector["id"];
					aux.Titulo = (string)lector["titulo"];
					aux.FechaLanzamiento = (DateTime)lector["fechalanzamiento"];
					aux.UrlImagen = (string)lector["urlimagen"];
					aux.Genero = new Genero();
					aux.Genero.Id = (int)lector["idgenero"];
					aux.Genero.Descripcion = (string)lector["Genero"];
					aux.Edicion = new Edicion();
					aux.Edicion.Id = (int)lector["idtipoedicion"];
					aux.Edicion.Descripcion = (string)lector["Edicion"];
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

		public void Agregar(Pelicula pelicula)
		{
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=PELICULAS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT INTO PELICULAS (titulo, fechalanzamiento, urlimagen, idgenero, idtipoedicion) values (@titulo,@fecha ,@url ,@idgenero ,@idtipoedicion)";
				comando.Parameters.AddWithValue("titulo", pelicula.Titulo);
                comando.Parameters.AddWithValue("fecha", pelicula.FechaLanzamiento);
                comando.Parameters.AddWithValue("url", pelicula.UrlImagen);
                comando.Parameters.AddWithValue("idgenero", pelicula.Genero.Id);
                comando.Parameters.AddWithValue("idtipoedicion", pelicula.Edicion.Id);
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

        public void Modificar(Pelicula pelicula)
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();	
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=PELICULAS_DB; integrated security = true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE PELICULAS SET titulo = @titulo, fechalanzamiento = @fecha, urlimagen = @url, idgenero = @idgenero, idtipoedicion = @idedicion WHERE id = @id;";
				comando.Parameters.AddWithValue("titulo", pelicula.Titulo);
                comando.Parameters.AddWithValue("fecha", pelicula.FechaLanzamiento);
                comando.Parameters.AddWithValue("url", pelicula.UrlImagen);
                comando.Parameters.AddWithValue("idgenero", pelicula.Genero.Id);
                comando.Parameters.AddWithValue("idedicion", pelicula.Edicion.Id);
                comando.Parameters.AddWithValue("id", pelicula.Id);
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
