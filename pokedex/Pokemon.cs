﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex
{
    internal class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; } //Asociacion de tipo composicion, los pokemons nacen con un tipo. Se componen.
        public Elemento Debilidad { get; set; }
    }
}
