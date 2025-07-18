﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EstiloNegocio
    {
        public List<Estilo> listar ()
        {
			List<Estilo> lista = new List<Estilo>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("SELECT id, descripcion FROM ESTILOS");
				datos.ejecutarLectura();
				
				while(datos.Lector.Read())
				{
					Estilo aux = new Estilo();
					aux.Id = (int)datos.Lector["id"];
					aux.Descripcion = (string)datos.Lector["descripcion"];

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
				datos.cerrarConexion();
			}
        }
    }
}
