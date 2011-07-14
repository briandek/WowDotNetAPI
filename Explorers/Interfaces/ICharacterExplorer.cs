using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Interfaces
{
    public interface ICharacterExplorer : IExplorer<Character>
    {
        Character GetCharacter(string realm, string name);
        Character GetCharacter(string region, string realm, string name);
    }
}
