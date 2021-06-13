using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TataCore.Dtos;
using TataCore.Entities;
using TataCore.Tools.Interfaces;

namespace TataCore.Tools.Implementations
{
    public class TextFilter : ITextFilter
    {
        public WordSearch CountWordAppearances(WordSearchDto data)
        {

            Regex regexExpression = new Regex(data.Pattern);
            var matches  =  regexExpression.Matches(data.Text);
            
            WordSearch result = new WordSearch()
            {
                Pattern = data.Pattern,
                Text = data.Text,
                TotalCount = matches.Count
            };

            return result ;
        }
    }
}
