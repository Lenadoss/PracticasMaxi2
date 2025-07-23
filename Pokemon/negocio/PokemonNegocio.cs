using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar ()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server = (localdb)\\MSSQLLocalDB; database = POKEDEX_DB; integrated security = true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT p.id, p.numero, p.nombre, p.descripcion, p.urlimagen, t.descripcion Tipo, d.descripcion Debilidad FROM Pokemons p, Elementos t, Elementos d WHERE p.idtipo = t.id AND p.iddebilidad = d.id;";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["id"];
                    aux.Numero = (int)lector["numero"];
                    aux.Nombre = (string)lector["nombre"];
                    aux.Descripcion = (string)lector["descripcion"];
                    aux.UrlImagen = (string)lector["urlimagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

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

        public void Agregar(Pokemon nuevoPokemon)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database = POKEDEX_DB; integrated security = true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO POKEMONS (numero, nombre, descripcion, urlimagen, idtipo, iddebilidad, activo) VALUES (" + nuevoPokemon.Numero + ", '" + nuevoPokemon.Nombre+ "', '" + nuevoPokemon.Descripcion + "', '', @idTipo, @idDebilidad, 1);";
                comando.Parameters.AddWithValue("idTipo", nuevoPokemon.Tipo.Id);
                comando.Parameters.AddWithValue("idDebilidad", nuevoPokemon.Debilidad.Id);
                conexion.Open();
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
    }
}
