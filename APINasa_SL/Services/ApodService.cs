using APINasa_SL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APINasa_SL.Services
{
    public class ApodService
    {
        public async Task<Apod> GetImage(DateTime dt)
        {
            Apod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MMdd")}&api_key=…";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<Apod>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }

}
