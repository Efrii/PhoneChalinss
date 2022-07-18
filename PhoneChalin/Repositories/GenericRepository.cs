using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneChalin.Context;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;
namespace PhoneChalin.Repositories
{
    public class GenericRepository<TModel, TPrimaryKey> : IGeneralRepository<TModel, TPrimaryKey>
        where TModel : class
    {
        internal readonly Uri baseAddress = new Uri("https://localhost:42573/api/");
        internal readonly HttpClient client;
        internal readonly string request;
        internal readonly IHttpContextAccessor accessor;

        public GenericRepository(string request)
        {
            this.request = request;
            accessor = new HttpContextAccessor();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessor.HttpContext.Session.GetString("Token"));
        }

        #region Get All Data
        public List<TModel> Get()
        {

            List<TModel> model = null;

            var responseTask = client.GetAsync(request);
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(readTask);
                var dataOnly = parsedObject["data"].ToString();

                model = JsonConvert.DeserializeObject<List<TModel>>(dataOnly);
            }

            return model;
        }
        #endregion Get All Data

        #region Get By Id
        public TModel Get(TPrimaryKey Id)
        {
            TModel model = null;

            var responseTask = client.GetAsync(request + Id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(readTask);
                var dataOnly = parsedObject["data"].ToString();

                model = JsonConvert.DeserializeObject<TModel>(dataOnly);
            }

            return model;
        }
        #endregion Get By Id

        #region Delete By Id
        public HttpStatusCode Delete(TPrimaryKey Id)
        {
            var deleteTask = client.DeleteAsync(request + Id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;

            return result.StatusCode;
        }
        #endregion Delete By Id

        #region Post Data
        public HttpStatusCode Post(TModel model)
        {
            var postTask = client.PostAsJsonAsync<TModel>(request, model);
            postTask.Wait();

            var result = postTask.Result;

            return result.StatusCode;
        }
        #endregion Post Data

        #region Edit Data
        public HttpStatusCode Put(TModel model)
        {
            var putTask = client.PutAsJsonAsync<TModel>(request, model);
            putTask.Wait();

            var result = putTask.Result;

            return result.StatusCode;
        }
        #endregion Edit Data
    }
}
