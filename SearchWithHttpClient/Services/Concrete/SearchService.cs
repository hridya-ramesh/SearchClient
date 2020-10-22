using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using SearchWithHttpClient.Services.Interface;
using SearchWithHttpClient.RegexUtility;

namespace SearchWithHttpClient.Services
{
    public class SearchService :ISearchService
    {
        public const string GoogleSearchUrl = "http://www.google.com.au/search?q=";
        public async Task<string>  SearchKeyWord(string searchKey, string searchUrl)
        {
            // accessing 20 items at a time and running tasks in parallel since 100 at a time could be  performance hit 
            Task<string> download1 = DownloadPageAsync(searchUrl, searchKey, 20, 0);
            Task<string> download2 = DownloadPageAsync(searchUrl, searchKey, 20, 20);
            Task<string> download3 = DownloadPageAsync(searchUrl, searchKey, 20, 40);
            Task<string> download4 = DownloadPageAsync(searchUrl, searchKey, 20, 60);
            Task<string> download5 = DownloadPageAsync(searchUrl, searchKey, 20, 80);
            // tasks will now run in parallel
            await Task.WhenAll(download1, download2, download3, download4, download5).ConfigureAwait(false);
          return (download1.Result+ download2.Result + download3.Result+ download4.Result+download5.Result);
        }
        /// <summary>
        /// Search Pages and get the URLs
        /// </summary>
        /// <param name="searchUrl"></param>
        /// <param name="searchKey"></param>
        /// <param name="pageLength"></param>
        /// <param name="startNumber"></param>
        /// <returns></returns>
        static async Task<string> DownloadPageAsync( string searchUrl, string searchKey,int pageLength , int startNumber)
        {
            string searchCount = string.Empty;
            string page = GoogleSearchUrl+ searchKey +"&num="+ pageLength +"&start="+startNumber;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response =  await client.GetAsync(page).ConfigureAwait(false))
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = await content.ReadAsStringAsync();
                    List<Uri> uris = RegexHelper.GetValidUri(result);
                    if (uris.Count > 0)
                    {
                        searchCount = String.Join(",", uris.Select((s, i) => new { Str = s, Index = i })
        .Where(x => x.Str.IsAbsoluteUri && x.Str.AbsoluteUri.Contains(searchUrl))
        .Select(x => x.Index + 1 + startNumber).ToList());
                    }
                    // searchCount += uris.FindIndex(x => x.AbsoluteUri.Contains(searchUrl)) > -1 ? (uris.FindIndex(x => x.AbsoluteUri.Contains(searchUrl)) + 1 + startNumber).ToString() + "," : string.Empty;//adding starting number of page as we are doing 20 items at a time
                }
            }
            return searchCount;
        }
    }
}