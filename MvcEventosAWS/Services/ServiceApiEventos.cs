using MvcEventosAWS.Models;
using System.Net.Http.Headers;

namespace MvcEventosAWS.Services
{
    public class ServiceApiEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiEventos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>
                ("ApiUrls:ApiEventosAWS");
            /*this.UrlApi = keys.ApiPersonajes;*/
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventos()
        {
            List<Evento> eventos = await this.CallApiAsync<List<Evento>>("/api/eventos/GetEventos");
            return eventos;
        }

        public async Task<List<Evento>> GetEventosPorCategorias(int id)
        {
            return await this.CallApiAsync<List<Evento>>("/api/eventos/GetEventosPorCategoria/" + id);
        }

        public async Task<List<CategoriaEvento>> GetCategoriasEventos()
        {
            List<CategoriaEvento> categorias = await this.CallApiAsync<List<CategoriaEvento>>("/api/eventos/GetCategoriasEventos");
            return categorias;
        }
    }
}
