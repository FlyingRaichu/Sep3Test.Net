namespace BlazorApp.Service;

public class NavService
{
    public ICollection<Item> SearchItems { get; set; }
    public Item Selected { get; set; }
}