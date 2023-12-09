using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.DTOs.DiscountCode;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

 public class DiscountCodeHttpClient : IDiscountCodeService
    {
        private readonly HttpClient client;

        public DiscountCodeHttpClient(HttpClient client)
        {
            this.client = client;
        }


        public async Task<DiscountCode> CreateAsync(DiscountCodeDto dto)
        {Console.WriteLine($"create async method: {dto.Code}, {dto.DiscountPercentage}");
            var response = await client.PostAsJsonAsync(requestUri: "/DiscountCodes", dto);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var discountCode = JsonSerializer.Deserialize<DiscountCode>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return discountCode;
        }

        public async Task DeleteAsync(int id)
        {
            var response = await client.DeleteAsync(requestUri: $"/discountCodes/{id}");
            
        }

        public async Task<ICollection<DiscountCode>> GetDiscountCodesAsync(string? code, int? discountPercentage)
        {
            var query = ConstructQuery(code, discountPercentage);
            var response = await client.GetAsync(requestUri: "/DiscountCodes" + query);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            var discountCodes = JsonSerializer.Deserialize<List<DiscountCode>>( content,new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            })!;
            var jsonDocument = JsonDocument.Parse(content);
            return discountCodes;
        }

        private static string ConstructQuery(string? code, int? discountPercentage)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(code))
            {
                queryParams.Add($"code={Uri.EscapeDataString(code)}");
            }

            if (discountPercentage != null)
            {
                queryParams.Add($"discountPercentage={discountPercentage}");
            }

            return queryParams.Any() ? "?" + string.Join("&", queryParams) : "";
        }

    }