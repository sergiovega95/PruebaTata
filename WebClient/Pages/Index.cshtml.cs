using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TataCore.Dtos;
using TataCore.Entities;
using TataCore.Tools.Interfaces;

namespace WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITextFilter _filter;

        public IndexModel(ILogger<IndexModel> logger , ITextFilter filter)
        {
            _logger = logger;
            _filter = filter;
        }


        /// <summary>
        /// Metodo que genera la vista
        /// </summary>
        public void OnGet()
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Metodo de que permite encontrar las veces que aparece una palabra en un texto
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>       
        public IActionResult OnPostSearchWord(WordSearchDto data)
        {
            try
            {
                WordSearch response = _filter.CountWordAppearances(data);
                return StatusCode(200,response);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocurrió un error al buscar el la palabra dentro del texto",e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
