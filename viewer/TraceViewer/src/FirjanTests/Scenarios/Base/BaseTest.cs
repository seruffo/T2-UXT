using Firjan.Integracao.Dynamics.Tests.Fixtures;
using FirjanTests.Fixtures;
using FirjanTests.Model;
using FirjanTests.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FirjanTests.Scenarios.Base
{
    public abstract class BaseTest
    {
        public bool IsSuccess { get; set; } = false;
        public string Controllers { get; set; }
        private string[] FieldOrderBy { get; set; } = new[] { "Id" };
        private string[] Id { get; set; } = new[] { "0" };
        private string Method { get; set; } = string.Empty;
        private string[] ParamMethod { get; set; } = new[] { "0" };
        public dynamic Body { get; set; }
        protected string RandTest { get { return new Random().Next(0, 10000).ToString(); } }
 
        private HttpRequestMessage Request(HttpMethod method, string Uri = null) => 
            new HttpRequestMessage(method, $"{Uri??Url}") { Content = new StringContent(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json") };

        public void Configure(string controllers, string id = null, string fieldOrderBy = null, string method = null, string paramMethod = null)
        {
            Controllers = controllers;
            Id = id.AsParameters();
            if(fieldOrderBy != null) FieldOrderBy = fieldOrderBy.AsParameters();
            Method = method ?? Method;
            ParamMethod = paramMethod.AsParameters();
        }
       
        public string UrlGetAll => String.Format("{0}/GetAll/{1}/asc/50/0", Url, FieldOrderBy.GetPath()); 

        private string GetPath() => Method.GetPath() != string.Empty ? string.Concat(Method.GetPath(), ParamMethod.GetPath()) : Id.GetPath();
        
        public string UrlGet => String.Format("{0}/{1}",Url, GetPath()); 

        public string Url => String.Format("/api/{0}/v1", Controllers);

        public string GetUrl(string url) => !string.IsNullOrEmpty(url) ? string.Concat(Url, '/', url) : null; 

        public ApiContext ApiContext => ApiContext.Instance;

        public static HttpClient Client;

        protected BaseTest()
        {
            Client = ApiContext.Instance.Client;
            PrepareToken();
        }

        internal void PrepareToken()
        {
            Body = new { login = ApiContext.Login, accessKey = ApiContext.AccesKey };

            var response = Client.SendAsync(Request(HttpMethod.Post, ApiContext.UrlToken)).Result;

            if (IsSuccess = response.IsSuccessStatusCode)
            {
                var token = response.Content.ReadAsAsync<Token>().Result;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.accessToken);
            }
        }

        internal void  GetAll(string url = null)
        {
            var response = Client.GetAsync(GetUrl(url)??UrlGetAll).Result;

            if (IsSuccess = response.IsSuccessStatusCode)
            {
                Body = response.Content.ReadAsAsync<Retorno>().Result.data;
            }
        }

        internal void Get(string url = null) 
        {
            var response = Client.GetAsync(GetUrl(url)??UrlGet).Result;

            if (IsSuccess = response.IsSuccessStatusCode)
            {
                Body = response.Content.ReadAsAsync<Retorno>().Result.data;
            }
        }

        internal void Send(HttpMethod method)
        {
            var response = Client.SendAsync(Request(method)).Result;
            
            if (IsSuccess = response.IsSuccessStatusCode)
            {
                Body = response.Content.ReadAsAsync<Retorno>().Result.data;
            }
        } 

        internal void Post() => Send(HttpMethod.Post);

        internal void Put() => Send(HttpMethod.Put);

        internal void Delete() => Send(HttpMethod.Delete);
    }
}