using System;
using System.Collections.Generic;
using System.Text;
using TataCore.Dtos;
using TataCore.Entities;

namespace TataCore.Tools.Interfaces
{
    public interface ITextFilter
    {
        WordSearch CountWordAppearances(WordSearchDto data);
    }
}
