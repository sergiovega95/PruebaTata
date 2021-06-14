using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TataCore.Dtos;
using TataCore.Entities;
using TataCore.Exceptions;
using TataCore.Tools.Interfaces;

namespace TataCore.Tools.Implementations
{
    public class TextFilter : ITextFilter
    {
        public WordSearch CountWordAppearances(WordSearchDto data)
        {
            if (string.IsNullOrEmpty(data.Text) || string.IsNullOrEmpty(data.Pattern))
            {
                throw new FilterCustomException("Falta información por enviar");
            }

            //Eliminando caracteres no necesarios
            data.Pattern = data.Pattern.Replace(".", "");
            data.Pattern = data.Pattern.Replace(",", "");
            data.Pattern = data.Pattern.Trim();
           
            //Texto y patrón el minuscula para evitar problemas.
            data.Text = data.Text.ToLower();
            data.Pattern = data.Pattern.ToLower();

            List<string> words = new List<string>();
            int matches = 0;
           
            if (data.Pattern.Length>0)
            {
                words= new List<string>(data.Text.Split(' '));
            }

            if (words.Any())
            {
                matches = words.Where(s => s == data.Pattern).ToList().Count;
            }           

            WordSearch result = new WordSearch()
            {
                Pattern = data.Pattern,
                Text = data.Text,
                TotalCount = matches
            };

            return result;
        }
    }
}
