using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Signature.WebAPI.Entities.Reposnse;
using Signature.WebAPI.Entities.Requests;
using Signature.WebAPI.Models;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Signature.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // GET: api/Token/GeneratedToken
        [HttpGet]
        public OpenIdTokenClientCredentials GeneratedToken()
        {
            string url = "https://apieversaaspre.everilion.com/enabler/security/api/openid/v1/connect/token";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                StringBuilder raw = new StringBuilder();
                string separator = "&";
                raw.Append("scope=api");
                raw.Append(separator);
                raw.Append("grant_type=client_credentials");
                raw.Append(separator);
                raw.Append($"client_id={"2541a8fb-fba9-4b37-b321-edab385b9a23"}");
                raw.Append(separator);
                raw.Append($"client_secret={"beIN1}J)yLf(wGlf8ePwlChqbi2wfIz6OcGz=u=CaJ*lus.SJIK,gtIGczyYevIA"}");

                streamWriter.Write(raw.ToString());
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = streamReader.ReadToEnd();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var OpenIdToken = JsonConvert.DeserializeObject<OpenIdTokenClientCredentials>(response);
                    return OpenIdToken;
                }
                else
                {
                    return new OpenIdTokenClientCredentials();
                }
            }
        }

        // GET: api/Token/GetStocksByReference
        [HttpGet]
        public async Task<ArticleStockResponse> GetStocksByReference([FromBody] GetStocksByReferenceRequest request)
        {
            //string url = "https://preproduccion.everilion.com/IlionServices4/everilion-erp-web-service-articlestocks/v1/GetArticleStockDataTransfer";

            var OpenIdToken = GeneratedToken();
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(OpenIdToken.access_token) as JwtSecurityToken;
            string idWeb = jwt.Claims.First(claim => claim.Type == "idweb").Value;

            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //webRequest.Method = "GET";
            //webRequest.Headers.Add("Authorization", string.Concat(OpenIdToken.token_type, " ", OpenIdToken.access_token));
            //webRequest.Headers.Add("Ocp-Apim-Subscription-Key", suscriptionKey);
            //webRequest.Headers.Add("backend-instance", backendInstance);
            //webRequest.Headers.Add("idweb", idWeb);

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://preproduccion.everilion.com/IlionServices4/everilion-erp-web-service-articlestocks/v1/GetArticleStockDataTransfer";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(OpenIdToken.token_type, OpenIdToken.access_token);

            //var response = await client.PostAsync(url, data);
            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<ArticleStockResponse>(result);
                return res;
            }
            else
            {
                return new ArticleStockResponse();
            }


            //var byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));

            //webRequest.ContentType = "application/json";
            //webRequest.ContentLength = byteArray.Length;

            //using var reqStream = webRequest.GetRequestStream();
            //reqStream.Write(byteArray, 0, byteArray.Length);

            //using var response = webRequest.GetResponse();

            //using var respStream = response.GetResponseStream();

            //using var reader = new StreamReader(respStream);
            //string data = reader.ReadToEnd();

            ////using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            ////{
            ////    streamWriter.Write(JsonConvert.SerializeObject(request));
            ////}

            //var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var response = streamReader.ReadToEnd();
            //    if (httpResponse.StatusCode == HttpStatusCode.OK)
            //    {
            //        var res = JsonConvert.DeserializeObject<ArticleStockResponse>(response);
            //        return res;
            //    }
            //    else
            //    {
            //        return new ArticleStockResponse();
            //    }
            //}
        }
    }
}