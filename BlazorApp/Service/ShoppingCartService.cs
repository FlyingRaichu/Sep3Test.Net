using System.Text.Json;
using Microsoft.JSInterop;

namespace BlazorApp.Service;

public class ShoppingCartService
{
   private readonly IJSRuntime _jsRuntime;
   private static readonly Random random = new Random();
   
        public Order Order { get; private set; } = new()
        {
            Id = random.Next()
        };
        
        private int itemIdCounter = 1;

        public ShoppingCartService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task OnInitializedAsync()
        {
                await LoadShoppingCartAsync();
        }
        
        private async Task LoadShoppingCartAsync()
        {
            try
            {
                // Load shopping cart from localStorage
                var orderJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "shoppingCart");
                Console.WriteLine("Loaded shopping cart: " + orderJson);
                if (!string.IsNullOrEmpty(orderJson))
                {
                    
                    var jsonDocument = JsonDocument.Parse(orderJson);
                    var root = jsonDocument.RootElement;
                    var itemsArray = root.GetProperty("Items").EnumerateArray();
                    var loadedOrder = JsonSerializer.Deserialize<Order>(orderJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })!;
                    
                    Console.WriteLine(loadedOrder.Id);

                    Order = loadedOrder;
                    
                    foreach (var orderItem in itemsArray.Select(itemJson => new OrderItem
                             {
                                 Id = GenerateUniqueItemId(),
                                 ItemId = itemJson.GetProperty("ItemId").GetInt32(),
                                 OrderId = itemJson.GetProperty("OrderId").GetInt32(),
                                 Quantity = itemJson.GetProperty("Quantity").GetInt32(),
                             }))
                    {
                        Order.Items.Add(orderItem);
                    }
                }
                else
                {
                    Order = new Order();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading shopping cart: " + ex.Message);
            }
        }

        private async Task SaveShoppingCartAsync()
        {
            try
            {
                // Save shopping cart to localStorage
                var orderJson = JsonSerializer.Serialize(Order);
                Console.WriteLine("Saving shopping cart: " + orderJson);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "shoppingCart", orderJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving shopping cart: " + ex.Message);
            }
        }

        public async Task AddOrderItem(int itemId, int quantity)
        {
            var id = 1;

            if (Order.Items.Any())
            {
                id = Order.Items.Max(i => i.Id) + 1;
            }

            var itemToAdd = new OrderItem()
            {
                Id = id,
                ItemId = itemId,
                Quantity = quantity
            };

            var existingItem = Order.Items.FirstOrDefault(oI => oI.ItemId == itemToAdd.ItemId);

            if (existingItem != null)
            {
                existingItem.Quantity += itemToAdd.Quantity;
            }
            else
            {
                Order.Items.Add(itemToAdd);
            }

            await SaveShoppingCartAsync();
        }

        private int GenerateUniqueItemId()
        {
            if (!Order.Items.Any()) return itemIdCounter;
            itemIdCounter = Order.Items.Max(i => i.Id);
            itemIdCounter++;

            return itemIdCounter;
        }
}