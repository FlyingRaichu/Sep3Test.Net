namespace HttpClients.Implementations;

public class DiscountBannerService
{
    public event Action<bool> OnDiscountChanged;

    private bool showDiscountBanner = false;

    public bool ShowDiscountBanner
    {
        get => showDiscountBanner;
        set
        {
            if (showDiscountBanner != value)
            {
                showDiscountBanner = value;
                OnDiscountChanged?.Invoke(showDiscountBanner);
            }
        }
    }
}