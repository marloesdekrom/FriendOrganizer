using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Lookups
{
    public interface IProgrammingLanguageDataService
    {
       Task<IEnumerable<LookupItem>> GetProgrammingLanguageLookupAsync();
    }
}