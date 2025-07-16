using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace pokedex
{
    internal class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {

            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector; // set de datos es almacenado en el lector. No se genera instancia porque esto devuelve un objeto del tipo de la clase. No tiene constructor.

            try
            {
                conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT numero, nombre, p.descripcion, urlimagen, e.descripcion Tipo, d.Descripcion Debilidad FROM POKEMONS p, ELEMENTOS e, ELEMENTOS d WHERE p.IdTipo = e.Id and p.IdDebilidad = d.Id;";
                comando.Connection = conexion; // ejecuta el comando en esa conexion.

                conexion.Open();
                lector = comando.ExecuteReader(); //esto devuelve la instancia del SqlDataReader (un objeto de esa clase).

                while (lector.Read()) // esto devuelve un arreglo, por lo tanto si tenemos info en el mismo sera true y entrara al while, podemos acceder a ellos
                                      // mediante el indice como en los arreglos convencionales.
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["nombre"]; //tienes que poner el mismo nombre de la columna, si es un apodo tiene que ser el nombre del apodo.
                    aux.Descripcion = (string)lector["descripcion"];
                    aux.UrlImagen = (string)lector["urlimagen"];
                    aux.Tipo = new Elemento(); //HAY QUE CREAR LA INSTANCIA, EL AUX.TIPO = ES UNA ASOCIACION CON LA CLASE ELEMENTO, EL OBJETO NO EXISTIA, POR LO TANTO SI INTENTAMOS ACCEDER A LA PROPIEDAD DESCRIPCION NO PODRIAMOS PORQUE NI SIQUIERA EXISTE LA INSTANCIA DE LA CLASE.
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux); //el lector va elemento por elemento y cada vez que lee agrega a la lista. 
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conexion.Close(); // lo que hace el finally es directamente cerrar la conexion AUNQUE sea atrapada una excepcion.
            }
        }
    }
}
