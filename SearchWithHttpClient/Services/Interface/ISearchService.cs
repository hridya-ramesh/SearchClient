using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithHttpClient.Services.Interface
{
   public interface ISearchService
    {
         Task<string> SearchKeyWord(string searchKey, string searchUrl);
    }
}
