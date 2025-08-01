using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				comando.CommandText = "SELECT d.id, d.titulo, d.fechalanzamiento, d.cantidadcanciones, d.urlimagentapa, e.descripcion Estilo, te.descripcion Edicion, d.idestilo, d.idtipoedicion FROM discos d, estilos e, tiposedicion te WHERE idestilo = e.id AND idtipoedicion = te.id AND Activo = 1";
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

					//if (!(lector.IsDBNull(lector.GetOrdinal("urlimagentapa"))))
					//	aux.UrlImagenTapa = (string)lector["urlimagentapa"];

					if (!(lector["urlimagentapa"] is DBNull))
						aux.UrlImagenTapa = (string)lector["urlimagentapa"];

					aux.Estilo = new Estilo();
					aux.Estilo.Id = (int)lector["idestilo"];
					aux.Estilo.Descripcion = (string)lector["Estilo"];
					aux.Edicion = new Edicion();
					aux.Edicion.Id = (int)lector["idtipoedicion"];
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
		public void Agregar(Disco nuevoDisco)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=DISCOS_DB; integrated security = true; ";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT INTO DISCOS (titulo, fechalanzamiento, cantidadcanciones, urlimagentapa, idestilo, idtipoedicion) VALUES ('" + nuevoDisco.Titulo+ "', '" + nuevoDisco.FechaLanzamiento.ToString("MM/dd/yyyy") + "', " +nuevoDisco.CantidadCanciones+ ", @urlImagenTapa, @idEstilo, @idEdicion);";
				comando.Parameters.AddWithValue("idEstilo", nuevoDisco.Estilo.Id);
				comando.Parameters.AddWithValue("idEdicion", nuevoDisco.Edicion.Id);
				comando.Parameters.AddWithValue("urlImagenTapa", nuevoDisco.UrlImagenTapa);
				conexion.Open();                                                                   // MI COMPUTADORA ES REGION=DOM POR LO TANTO HAY QUE MODIFICAR EL FORMATO PARA QUE SEA ACEPTADO POR SQL CUANDO ENVIAMOS LA CONSULTA.
				comando.Connection = conexion; 
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

        public void Modificar(Disco disco)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = DISCOS_DB; integrated security= true;";
				comando.Connection = conexion;
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE DISCOS SET titulo = @titulo, fechalanzamiento = @fecha , cantidadcanciones = @cantidad , urlimagentapa = @url, idestilo = @idestilo, idtipoedicion = @idtipoedicion WHERE id = @id;";
				comando.Parameters.AddWithValue("Id", disco.Id);
                comando.Parameters.AddWithValue("titulo", disco.Titulo);
                comando.Parameters.AddWithValue("fecha", disco.FechaLanzamiento);
                comando.Parameters.AddWithValue("cantidad", disco.CantidadCanciones);
                comando.Parameters.AddWithValue("url", disco.UrlImagenTapa);
                comando.Parameters.AddWithValue("idestilo", disco.Estilo.Id);
                comando.Parameters.AddWithValue("idtipoedicion", disco.Edicion.Id);
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
				conexion.ConnectionString = "server = (localdb)\\MSSQLLocalDB; database = DISCOS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "DELETE FROM DISCOS WHERE ID = @id";
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
				conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = DISCOS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE DISCOS SET ACTIVO = 0 WHERE ID = @id";
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

        public List<Disco> Filtrar(string campo, string criterio, string filtro)
        {
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			List<Disco> listaFiltrada = new List<Disco>();
			string consulta = "SELECT d.id, d.titulo, d.fechalanzamiento, d.cantidadcanciones, d.urlimagentapa, e.descripcion Estilo, te.descripcion Edicion, d.idestilo, d.idtipoedicion FROM discos d, estilos e, tiposedicion te WHERE idestilo = e.id AND idtipoedicion = te.id AND Activo = 1 AND ";
			try
			{
                switch (campo)
                {
                    case "Id":
                        switch (criterio)
                        {
                            case "Mayor que":
                                consulta += "d.id > " + filtro;
                                break;

                            case "Menor que":
                                consulta += "d.id < " + filtro;
                                break;

                            case "Igual que":
                                consulta += "d.id = " + filtro;
                                break;
                        }
                        break;

                    case "Titulo":
                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "d.titulo LIKE '%" + filtro + "%' ";
                                break;

                            case "Empieza con":
                                consulta += "d.titulo LIKE '" + filtro + "%' ";
                                break;

                            case "Termina con":
                                consulta += "d.titulo LIKE '%" + filtro + "' ";
                                break;
                        }
                        break;

                    case "Edicion":
                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "te.descripcion LIKE '%" + filtro + "%' ";
                                break;

                            case "Empieza con":
                                consulta += "te.descripcion LIKE '" + filtro + "%' ";
                                break;

                            case "Termina con":
                                consulta += "te.descripcion LIKE '%" + filtro + "' ";
                                break;
                        }
                        break;
                }
                conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = DISCOS_DB; integrated security = true;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = consulta;
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();
				while (lector.Read())
				{
                    Disco aux = new Disco();
                    aux.Id = (int)lector["id"];
                    aux.Titulo = (string)lector["titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["fechalanzamiento"];
					aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    if (!(lector["urlimagentapa"] is DBNull))
                        aux.UrlImagenTapa = (string)lector["urlimagentapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)lector["idestilo"];
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)lector["idtipoedicion"];
                    aux.Edicion.Descripcion = (string)lector["Edicion"];
                    listaFiltrada.Add(aux);
                }
				lector?.Close();
				return listaFiltrada;
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



