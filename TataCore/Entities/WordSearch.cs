using System;
using System.Collections.Generic;
using System.Text;

namespace TataCore.Entities
{
    public class WordSearch
    {
        /// <summary>
        /// Palabra la cual se desea saber su cantidad de apariciones en un texto 
        /// </summary>
        public string Pattern { get; set; }


        /// <summary>
        /// Texto donde se buscara el pattern
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// Cantidad de veces que aparece el Pattern en el texto
        /// </summary>
        public int TotalCount { get; set; }
    }
}
