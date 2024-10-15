using eShop.Aggregator.Contracts;
using eShop.Aggregator.Models;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace eShop.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CatalogModel>> GetProducts(string? filter, string? orderBy, int? page, int? pageSize)
        {
            var response = await _httpClient.GetAsync($"/api/Product/GetProducts?filter={filter}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
            return await response.Content.ReadFromJsonAsync<List<CatalogModel>>();
        }
    }
}
