using JWT.Algorithms;
using JWT.Builder;
using Pusula.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web.Http;

namespace Pusula.Controllers
{
    public class SorguController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Language(string searchText = "")
        {
            HttpWebRequest httpWebRequest = System.Net.WebRequest.Create("https://restcountries.eu/rest/v2/all?fields=name;languages") as HttpWebRequest;
            using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Sunucu Hatası (HTTP {0}: {1}).",
                        httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
                }
                Stream stream = httpWebResponse.GetResponseStream();
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(FilteredCountry[]));
             
                FilteredCountry[] result = (FilteredCountry[])dataContractJsonSerializer.ReadObject(stream);

                if (result == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Ülke Bulunamadı.");
                }
                else
                {

                    string[] langs = result.Where(a => a.name.ToLower() == searchText.ToLower()).FirstOrDefault().languages.Select(a=>a.name).ToArray();

                    return Request.CreateResponse<string>(HttpStatusCode.OK, string.Join(",",langs));
                }
            }
        }
    }
}