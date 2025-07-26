using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominioo
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        [DisplayName("Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        public string UrlImagen { get; set; }
        public Genero Genero { get; set; }
        public Edicion Edicion { get; set; }

    }
}
