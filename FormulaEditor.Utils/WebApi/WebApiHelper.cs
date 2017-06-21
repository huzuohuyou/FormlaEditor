using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FormulaEditor.Utils.WebApi
{
    public static class WebApiHelper
    {
        public static readonly string BaseUrl = "http://localhost:6920//";

        #region 字典传参

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        public static async void doGet(string url, IWork work)
        {
            try
            {
                url = BaseUrl + url;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (var http = new HttpClient(handler))
                {
                    var response = await http.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    work.Do(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                work.SendExMsg(ex.Message);
            }
            
        }
        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static async void doPost(string url, Dictionary<string, string> data, IWork work)
        {
            try
            {
                url = BaseUrl + url;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (var http = new HttpClient(handler))
                {
                    var content = new FormUrlEncodedContent(data);
                    var response = await http.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    work.Do(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        public static async void doPut(string url, Dictionary<string, string> data, IWork work)
        {
            try
            {
                url = BaseUrl + url;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (var http = new HttpClient(handler))
                {
                    var content = new FormUrlEncodedContent(data);
                    var response = await http.PutAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    work.Do(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }


        #endregion


        #region 实体传参
        public static async void doPut<T>(string url, T param, IWork work)
        {
            try
            {
                url = BaseUrl + url;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (var client = new HttpClient(handler))
                {
                    var response = await client.PutAsync(url, param, formatter);
                    response.EnsureSuccessStatusCode();
                    work.Do(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static async void doPost<T>(string url, T param, IWork work)
        {
            try
            {
                url = BaseUrl + url;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (var client = new HttpClient(handler))
                {
                    var response = await client.PostAsync(url, param, formatter);
                    response.EnsureSuccessStatusCode();
                    work.Do(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private static JsonMediaTypeFormatter formatter = GlobalConfiguration.Configuration.Formatters.Where(f =>
        {
            return f.SupportedMediaTypes.Any(v => v.MediaType.Equals("application/json", StringComparison.CurrentCultureIgnoreCase));
        }).FirstOrDefault() as JsonMediaTypeFormatter;

        #endregion


    }
}
