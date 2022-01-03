using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DAL
{
    public interface IAWSCore
    {
        public Task<string> SearchData(string SearchkeyValues,string DomainURL);
    }
}
