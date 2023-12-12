using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

public class OrderHttpClient : IOrderService
{
    private readonly HttpClient client;
    

    public OrderHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Order>> GetOrdersAsync(string? orderFullName, int? postalCode, string? address, string? city, long? phoneNumber,
        string? status, string? date)
    {
        var query = ConstructQuery(orderFullName, postalCode, address, city, phoneNumber, status, date);

        var response = await client.GetAsync("/Orders" + query);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var orders = JsonSerializer.Deserialize<List<Order>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return orders;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/Orders", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var order = JsonSerializer.Deserialize<Order>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return order;
    }

    public async Task UpdateAsync(OrderUpdateDto dto)
    {
        var response = await client.PatchAsJsonAsync("/Orders", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"/Orders/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var response = await client.GetAsync($"/Orders/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var order = JsonSerializer.Deserialize<Order>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllByUserIdAsync(int userId)
    {
        var response = await client.GetAsync($"/history/{userId}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var orders = JsonSerializer.Deserialize<List<Order>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        /*
         * it doesn't auto-deserialize the order items within the order. so u gotta
         * find them and manually map them
         */
        
        var jsonDocument = JsonDocument.Parse(content);

        foreach (var order in orders)
        {
            var orderItemsJson = jsonDocument.RootElement
                .EnumerateArray()
                .Where(j => j.GetProperty("id").GetInt32() == order.Id)
                .Select(j => j.GetProperty("items").EnumerateArray())
                .SelectMany(itemArray => itemArray.Select(item => new OrderItem
                {
                    Id = item.GetProperty("id").GetInt32(),
                    ItemId = item.GetProperty("itemId").GetInt32(),
                    OrderId = item.GetProperty("orderId").GetInt32(),
                    Quantity = item.GetProperty("quantity").GetInt32()
                }));

            order.Items.AddRange(orderItemsJson);
        }
        
        return orders;
    }

    public async Task<OrderItem> AddItemToOrderAsync(OrderItemCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/orderItems", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var orderItem = JsonSerializer.Deserialize<OrderItem>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return orderItem;
    }

    public async Task UpdateItemInOrderAsync(OrderItemUpdateDto dto)
    {
        var response = await client.PatchAsJsonAsync("/orderItems", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteItemInOrderAsync(int orderItemId, int orderId)
    {
        var response = await client.DeleteAsync($"/orderItems/{orderItemId}");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    private static string ConstructQuery(string? orderFullName, int? postalCode, string? address, string? city, long? phoneNumber, string? status, string? date)
    {
        var parameters = new List<string>();

        if (!string.IsNullOrEmpty(orderFullName))
        {
            parameters.Add($"orderFullName={Uri.EscapeDataString(orderFullName)}");
        }

        if (postalCode != null)
        {
            parameters.Add($"postalCode={postalCode}");
        }

        if (!string.IsNullOrEmpty(address))
        {
            parameters.Add($"address={Uri.EscapeDataString(address)}");
        }

        if (!string.IsNullOrEmpty(city))
        {
            parameters.Add($"city={Uri.EscapeDataString(city)}");
        }

        if (phoneNumber != null)
        {
            parameters.Add($"phoneNumber={phoneNumber}");
        }

        if (!string.IsNullOrEmpty(status))
        {
            parameters.Add($"status={Uri.EscapeDataString(status)}");
        }

        if (!string.IsNullOrEmpty(date))
        {
            parameters.Add($"date={Uri.EscapeDataString(date)}");
        }

        return parameters.Any() ? "?" + string.Join("&", parameters) : string.Empty;
    }
}