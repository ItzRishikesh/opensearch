
using Amazon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Models
{
    public class Search : IAWSCore
    {
        public async Task<string> SearchData(string SearchkeyValue, string DomainURL)
        {
            dynamic res = null;
            Amazon.Util.AWSHttpClient http = new Amazon.Util.AWSHttpClient();
            http.BaseAddress = new Uri(DomainURL + "_search?q=Market:" + SearchkeyValue);
            res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri);

            if (res == null)
            {
                http.BaseAddress = new Uri(DomainURL + "/_search?q=Name:" + SearchkeyValue);


                res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri);
            }
            else if (res.Content == null)
            {
                http.BaseAddress = new Uri(DomainURL + "/_search?q=FormerName:" + SearchkeyValue);

                res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri); ;
            }
            else if (res.Content == null)
            {
                http.BaseAddress = new Uri(DomainURL + "/_search?q=StreetAddress:" + SearchkeyValue);

                res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri); ;
            }
            else if (res.Content == null)
            {
                http.BaseAddress = new Uri(DomainURL + "/_search?q=City:" + SearchkeyValue);

                res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri); ;
            }
            else if (res.Content == null)
            {
                http.BaseAddress = new Uri(DomainURL + "/_search?q=State:" + SearchkeyValue);
                res = await http.GetResponseHeadersAsync("POST", http.BaseAddress.AbsoluteUri); ;
            }


            return res.Content.ToString();
        }

        public void index()
        {
            AWSStreamContent content=null;
            var endPoint = new Amazon.Util.AWSHttpClient();
            Dictionary<string, string> hewaders = new Dictionary<string, string>();
            hewaders.Add("method", "post");
            hewaders.Add("body", "{'name':'rishikesh' }");
            endPoint.PutRequestUriAsync(endPoint.BaseAddress.AbsoluteUri, content, hewaders);
        }
    }
}
