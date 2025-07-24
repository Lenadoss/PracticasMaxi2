using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [DisplayName("Fecha de lanzamiento del album")]
        public DateTime FechaLanzamiento { get; set; }
        [DisplayName("Url del cover")]
        public string UrlImagenCover { get; set; }
        public Genero Genero { get; set; }
        public Edicion Edicion { get; set; }

    }
}
